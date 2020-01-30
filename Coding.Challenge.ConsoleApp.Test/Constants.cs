using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Coding.Challenge.ConsoleApp.Test
{
    internal class Constants
    {
        public const string FilePath = "./eBook.txt";

        public static readonly IReadOnlyDictionary<string, int> Expected = new ReadOnlyDictionary<string, int>(new Dictionary<string, int>
        {
            {"the", 4284},
            {"and", 2192},
            {"of", 2185},
            {"a", 1861},
            {"to", 1685},
            {"in", 1366},
            {"i", 1056},
            {"that", 1024},
            {"his", 889},
            {"it", 821},
            {"he", 783},
            {"but", 616},
            {"was", 603},
            {"with", 595},
            {"s", 577},
            {"is", 564},
            {"for", 551},
            {"all", 542},
            {"as", 541},
            {"at", 458}
        });
    }
}