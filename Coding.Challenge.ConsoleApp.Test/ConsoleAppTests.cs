using Xunit;

namespace Coding.Challenge.ConsoleApp.Test
{
    public class ConsoleAppTests
    {
        [Fact]
        public void ParseTextFile_GivenEBookDotTxt_ReturnsSameCountsAsBashExample()
        {
            var actual = Program.ParseTextFile(Constants.FilePath);

            Assert.Equal(Constants.Expected, actual);
        }
    }
}