using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using BlitzkriegSoftware.Data.Maker.Libs;
using Newtonsoft.Json;

namespace BlitzkriegSoftware.Data.Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exitCode = 0;

            Title();

            var result = CommandLine.Parser.Default.ParseArguments<Models.CommandLineOptions>(args);

            if (result.Errors.Any())
            {
                exitCode = 1;
            }
            else
            {
                var options = result.Value;

                if (string.IsNullOrWhiteSpace(options.OutputFolder) || !System.IO.Directory.Exists(options.OutputFolder))
                {
                    options.OutputFolder = System.IO.Directory.GetCurrentDirectory();
                }

                if (options.NumberOfRecords <= 0)
                {
                    options.NumberOfRecords = 1;
                }

                List<Models.Person> list = new();

                for (int i = 0; i < options.NumberOfRecords; i++)
                {
                    Console.Write($"{i}..");
                    var person = ModelMaker.PersonMake();
                    if (options.AsArray)
                    {
                        list.Add(person);
                    }
                    else
                    {
                        var json = JsonConvert.SerializeObject(
                                        person,
                                        Newtonsoft.Json.Formatting.None,
                                        new Newtonsoft.Json.JsonSerializerSettings()
                                        {
                                            Converters = new List<Newtonsoft.Json.JsonConverter> {
                                                new Newtonsoft.Json.Converters.StringEnumConverter()
                                            }
                                        });
                        var filename = person._id.ToString() + ".json";
                        filename = System.IO.Path.Combine(options.OutputFolder, filename);
                        System.IO.File.WriteAllText(filename, json);
                    }
                }

                if (options.AsArray)
                {
                    var filename = options.OutputFilename;
                    if (string.IsNullOrWhiteSpace(filename)) filename = "datamaker-data.json";
                    filename = System.IO.Path.Combine(options.OutputFolder, filename);

                    var json = JsonConvert.SerializeObject(
                                        list,
                                        Newtonsoft.Json.Formatting.Indented,
                                        new Newtonsoft.Json.JsonSerializerSettings()
                                        {
                                            Converters = new List<Newtonsoft.Json.JsonConverter> {
                                                new Newtonsoft.Json.Converters.StringEnumConverter()
                                            }
                                        });

                    System.IO.File.WriteAllText(filename, json);
                }

                Environment.ExitCode = exitCode;
            }
        }
        static void Title()
        {
            Console.WriteLine($"{AssemblyHelper.GetTitle()} {AssemblyHelper.GetVersion()} {AssemblyHelper.GetCopyright()}");
        }

        static void Usage(string message, Models.CommandLineOptions? options)
        {
            if (!string.IsNullOrWhiteSpace(message)) Console.WriteLine(message);
        }
    }
}