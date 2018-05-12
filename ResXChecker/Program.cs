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
                if (parser.Result is CommandArgs.UnrefCommand)
                {
                    PrintUnreferenced(parser.Result as CommandArgs.UnrefCommand);
                }
                else
                {
                    parser.PrintUsage();
                }
            }

            return 0;
        }

        private static int PrintUnreferenced(CommandArgs.UnrefCommand cmd)
        {
            Checker.PrintUnreferenced(cmd.Resx, cmd.FileTypes, cmd.BaseDir);

            return 0;
        }
    }
}
