using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine.Text;
using CommandLine;

namespace BlitzkriegSoftware.Data.Maker.Models
{
    /// <summary>
    /// Command Line Options
    /// </summary>
    public class CommandLineOptions
    {
        /// <summary>
        /// Number of Records To Generate
        /// </summary>
        [Option('n', "Number_of_Records", Default = 100, HelpText = "Number of Records")]
        public int NumberOfRecords { get; set; }

        /// <summary>
        /// Output Folder
        /// </summary>
        [Option('o', "Output_Folder", Default = "", HelpText = "Output Folder")]
        public string? OutputFolder { get; set; }
        /// <summary>
        /// Data File Name
        /// </summary>

        [Option('d', "Data_File", Default = "datamaker-data.json", HelpText = "When used with -a name of file to use")]
        public string? OutputFilename { get; set; }

        /// <summary>
        /// Return as a json array
        /// </summary>
        [Option('a', "As JSON Array", Default = false, HelpText = "Output one file with all records as a JSON Array")]
        public bool AsArray { get; set; }
    }
}
