﻿namespace ResXChecker
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using fmdev.ArgsParser;

    public class CommandArgs
    {
        [Description("list unreferenced items from specified .resx file")]
        public class UnrefCommand : Command
        {
            //[CommandArg(HelpText = "dispay additional information")]
            //public bool Verbose { get; set; }

            [CommandArg(HelpText = "specify resx source file", IsRequired = true)]
            public string Resx { get; set; }

            [CommandArg(HelpText = "files to scan (default: *.cs;*.xaml)", IsRequired = false)]
            public string FileTypes { get; set; }

            [CommandArg(HelpText = "folder to search files within", IsRequired = false)]
            public string BaseDir { get; set; }

            ////[Option('s', "sorted", HelpText = "sort data alphabetically by name")]
            ////public bool IsSorted { get; set; }
        }

        /*[Description("write XLF translation data to specified .resx output file")]
        public class WriteTargetCommand : Command
        {
            [CommandArg(HelpText = "sort data alphabetically by name")]
            public bool Sorted { get; set; }

            [CommandArg(HelpText = "specify output resx file", IsRequired = true)]
            public string Resx { get; set; }

            [CommandArg(HelpText = "specify xlf input file", IsRequired = true)]
            public string Xlf { get; set; }

            [CommandArg(HelpText = "includes the first note as comment")]
            public bool IncludeComments { get; set; }
        }

        [Description("Export XLIFF translation units to a CSV file.")]
        public class ExportCsvCommand : Command
        {
            [CommandArg(HelpText = "specify xlf input file", IsRequired = true)]
            public string Xlf { get; set; }

            [CommandArg(HelpText = "the file to export into", IsRequired = true)]
            public string Out { get; set; }

            [CommandArg(HelpText = "the XLF dialect: MultilingualAppToolkit, RCWinTrans11, Standard (default)")]
            public string Dialect { get; set; }

            [CommandArg(HelpText = "restrict units to specified states (delimiter is ';')", IsRequired = false)]
            public string Filter { get; set; }

            [CommandArg(HelpText = "restrict units to specified restypes (delimiter is ';')", IsRequired = false)]
            public string ResTypeFilter { get; set; }

            [CommandArg(HelpText = "include a custom id as separate column", IsRequired = false)]
            public string CustomIdColumn { get; set; }

            [CommandArg(HelpText = "include the language as separate column", IsRequired = false)]
            public bool WithLanguage { get; set; }

            [CommandArg(HelpText = "do not include column names as first row of the CSV file", IsRequired = false)]
            public bool NoHeader { get; set; }
        }

        [Description("retrieve xlf file information")]
        public class InfoCommand : Command
        {
            [CommandArg(HelpText = "xlf input file", IsRequired = true)]
            public string Xlf { get; set; }
        }
        */
    }
}