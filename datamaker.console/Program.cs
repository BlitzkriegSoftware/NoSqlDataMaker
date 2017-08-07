using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using Newtonsoft.Json;

namespace datamaker.console
{
    class Program
    {
        static int Main(string[] args)
        {
            int exitCode = 0;

            Title();

            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.DoHelp)
                {
                    Usage(null, options);
                    exitCode = 1;
                }

                var outputFolder = Directory.GetCurrentDirectory();
                if (!string.IsNullOrWhiteSpace(options.OutputFolder))
                {
                    if (Directory.Exists(options.OutputFolder))
                    {
                        outputFolder = options.OutputFolder;
                    }
                    else
                    {
                        Usage("Bad Folder: " + options.OutputFolder, options);
                        exitCode = -1;
                    }
                }

                if (exitCode == 0)
                {
                    if (options.NumberOfRecords <= 0)
                    {
                        Usage("Number of records should be > 0", options);
                        exitCode = -2;
                    }
                    else
                    {
                        for (int i = 0; i < options.NumberOfRecords; i++)
                        {
                            Console.Write("{0}..", i);
                            var person = ModelMaker.PersonMake();
                            var json = JsonConvert.SerializeObject(
                                            person,
                                            Newtonsoft.Json.Formatting.None,
                                            new Newtonsoft.Json.JsonSerializerSettings()
                                            {
                                                Converters = new List<Newtonsoft.Json.JsonConverter> {
                                                    new Newtonsoft.Json.Converters.StringEnumConverter()
                                                }
                                            });
                            var filename = person.MemberId.ToString() + ".json";
                            filename = Path.Combine(outputFolder, filename);
                            File.WriteAllText(filename, json);
                        }
                        Console.WriteLine("Done");
                    }
                }
            }

            Environment.ExitCode = exitCode;
            return exitCode;
        }

        static void Title()
        {
            Console.WriteLine("{0} {1}", AssemblyHelper.GetTitle(), AssemblyHelper.GetVersion());
        }

        static void Usage(string message, Options options)
        {
            Console.WriteLine("{0}", options.GetUsage());
            if (!string.IsNullOrWhiteSpace(message)) Console.WriteLine(message);
        }

    }
}
