using BenchmarkDotNet.Running;

namespace Coding.Challenge.ConsoleApp.Test
{
    // Used to run BenchmarkRunner
    public class BenchmarkProgram
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConsoleAppBenchMarks>();
        }
    }
}
