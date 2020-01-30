using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Coding.Challenge.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please pass one argument, the filePath to the text file");
                Environment.Exit(-1); // Non zero exit code as something went wrong
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"{args[0]} not found");
                Environment.Exit(-1);

            }

            var parsedTextFile = ParseTextFile(args[0]).Select(x => $"{x.Value} {x.Key}");
            Console.Write(string.Join(Environment.NewLine, parsedTextFile));
        }

        
        public static IEnumerable<KeyValuePair<string, int>> ParseTextFile(string filePath)
        {
            var wordDictionary = new ConcurrentDictionary<string, int>();
            var allLines = ReadAllLines(filePath);

            Parallel.ForEach(allLines, currentLine =>
            {
                var matches = Regex.Matches(currentLine, @"\w+"); // Words no empty matches
                
                foreach (Match match in matches)
                {
                    var key = match.Value.ToLower();
                    wordDictionary.AddOrUpdate(key, 1, (k, oldValue) => oldValue + 1);
                }

            });

            return wordDictionary
                .OrderByDescending(x => x.Value)
                .Take(20);
        }

        private static IEnumerable<string> ReadAllLines(string filePath)
        {
            const int bufferSize = 65536;

            var allLines = new List<string>();
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None, bufferSize))
            {
                using var streamReader = new StreamReader(fileStream, Encoding.UTF8, false, bufferSize);
                string currentLine;

                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
