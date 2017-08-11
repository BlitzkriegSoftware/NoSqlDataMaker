using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamaker.console
{
    public class Options
    {
        [Option('n', "Number_of_Records", DefaultValue = 100, HelpText = "Number of Records")]
        public int NumberOfRecords { get; set; }

        [Option('o',"Output_Folder", DefaultValue ="", HelpText ="Output Folder" )]
        public string OutputFolder { get; set; }

        [Option('d', "Data_File",DefaultValue ="datamaker-data.json", HelpText ="When used with -a name of file to use")]
        public string OutputFilename { get; set; }

        [Option('a',"As JSON Array", DefaultValue =false, HelpText ="Output one file with all records as a JSON Array")]
        public bool AsArray { get; set; }

        [Option('h', "Help", HelpText = "Help", DefaultValue = false)]
        public bool DoHelp { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
