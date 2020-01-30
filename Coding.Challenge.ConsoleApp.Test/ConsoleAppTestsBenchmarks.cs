using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Coding.Challenge.ConsoleApp.Test
{
    public class ConsoleAppBenchMarks
    {
        private readonly Consumer consumer = new Consumer();

        [Benchmark]
        public void BenchmarkParseTextFile() => Program.ParseTextFile(Constants.FilePath).Consume(consumer);
    }
}
