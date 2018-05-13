namespace ResXChecker
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
        public class ListCommand : Command
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


        [Description("Remove unreferenced items from specified .resx file")]
        public class CleanCommand : Command
        {
            [CommandArg(HelpText = "do not write changes")]
            public bool DryRun { get; set; } = false;

            [CommandArg(HelpText = "specify resx source file", IsRequired = true)]
            public string Resx { get; set; }

            [CommandArg(HelpText = "files to scan (default: *.cs;*.xaml)", IsRequired = false)]
            public string FileTypes { get; set; }

            [CommandArg(HelpText = "folder to search files within", IsRequired = false)]
            public string BaseDir { get; set; }
        }
    }
}