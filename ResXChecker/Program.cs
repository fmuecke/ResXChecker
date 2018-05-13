using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResXChecker
{
    class Program
    {
        static int Main(string[] args)
        {
            var parser = new fmdev.ArgsParser.ArgsParser(typeof(CommandArgs));
            if (parser.Parse(args))
            {
                if (parser.Result is CommandArgs.ListCommand)
                {
                    ListUnreferenced(parser.Result as CommandArgs.ListCommand);
                }
                else if (parser.Result is CommandArgs.CleanCommand)
                {
                    CleanUnreferenced(parser.Result as CommandArgs.CleanCommand);
                }
                else
                {
                    parser.PrintUsage();
                }
            }

            return 0;
        }

        private static void CleanUnreferenced(CommandArgs.CleanCommand cmd)
        {
            Checker.CleanUnreferenced(cmd.Resx, cmd.FileTypes, cmd.BaseDir, cmd.DryRun);
        }

        private static int ListUnreferenced(CommandArgs.ListCommand cmd)
        {
            Checker.PrintUnreferenced(cmd.Resx, cmd.FileTypes, cmd.BaseDir);

            return 0;
        }
    }
}
