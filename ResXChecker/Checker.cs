using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResXChecker
{
    class Checker
    {
        internal static void PrintUnreferenced(string resx, string filePattern, string baseDir)
        {
            if (string.IsNullOrWhiteSpace(filePattern))
            {
                filePattern = "*.cs;*.xaml";
            }

            if (string.IsNullOrWhiteSpace(baseDir))
            {
                baseDir = System.IO.Directory.GetCurrentDirectory();
            }

            var entries = fmdev.ResX.ResXFile.Read(resx);
            entries = entries.OrderBy(e => e.Id).ToList();

            var files = System.IO.Directory.EnumerateFiles(baseDir, filePattern, System.IO.SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var content = System.IO.File.ReadAllText(file);
                foreach (var entry in entries.ToList())
                {
                    if (content.Contains(entry.Id))
                    {
                        entries.Remove(entry);
                    }
                }
            }

            Console.WriteLine($"{entries.Count} Unreferenced entries");
            entries.ForEach(e => Console.WriteLine(e.Id));
        }
    }
}
