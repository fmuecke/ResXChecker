using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResXChecker
{
    class Checker
    {
        private static List<string> GetFiles(string filePattern, string baseDir)
        {
            if (string.IsNullOrWhiteSpace(filePattern))
            {
                filePattern = "*.cs;*.xaml";
            }

            if (string.IsNullOrWhiteSpace(baseDir))
            {
                baseDir = System.IO.Directory.GetCurrentDirectory();
            }

            return filePattern.Split(';').SelectMany(pattern => System.IO.Directory.GetFiles(baseDir, pattern, System.IO.SearchOption.AllDirectories)).ToList();
        }

        internal static void PrintUnreferenced(string resx, string filePattern, string baseDir)
        {
            var entries = fmdev.ResX.ResXFile.Read(resx);

            foreach (var file in GetFiles(filePattern, baseDir))
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

            Console.WriteLine($"{entries.Count} unreferenced entries");
            entries.OrderBy(e => e.Id).ToList().ForEach(e => Console.WriteLine(e.Id));
        }

        internal static void CleanUnreferenced(string resx, string filePattern, string baseDir, bool dryRun)
        {
            var entries = fmdev.ResX.ResXFile.Read(resx);
            var referencedEntries = new List<fmdev.ResX.ResXEntry>();

            foreach (var file in GetFiles(filePattern, baseDir))
            {
                var content = System.IO.File.ReadAllText(file);
                foreach (var entry in entries.ToList())
                {
                    if (content.Contains(entry.Id))
                    {
                        referencedEntries.Add(entry);
                        entries.Remove(entry);
                    }
                }
            }

            Console.WriteLine($"Removing {entries.Count} unreferenced entries from {resx}...");
            //entries.OrderBy(e => e.Id).ToList().ForEach(e => Console.WriteLine(e.Id));
            if (dryRun)
            {
                Console.WriteLine($"dry run (nothing changed)");
            }
            else
            {
                fmdev.ResX.ResXFile.Write(resx, referencedEntries);
                Console.WriteLine($"{entries.Count} entries removed, {referencedEntries.Count} written");
            }
        }
    }
}
