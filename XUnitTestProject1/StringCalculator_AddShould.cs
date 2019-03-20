using System;
using StringCalculator;
using Xunit;

namespace XUnitTestProject1
{
    public class StringCalculator_AddShould
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(24, "24")]
        public void ReturnTheNumber_GivenSingleNumberString(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, "1,1")]
        [InlineData(3, "1,2")]
        [InlineData(13, "11,2")]
        public void ReturnSumOfNumbers_GivenTwoNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(11, "1,1,2,3,4")]
        [InlineData(9, "1,2,2,2,2")]
        [InlineData(36, "11,2,23")]
        public void ReturnSumOfNumbers_GivenMoreThanTwoNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(36, "11\n2,23")]
        [InlineData(46, "22\n2\n22")]
        public void ReturnSumOfNumbers_GivenNewLineSeparators(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, "//;\n1;2")]
        public void ReturnSumOfNumbers_GivenCustomDelimitedNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThrowException_GivenNegativeNumbers()
        {
            void TestCode() => Calculator.Add("-1,-4,7");
            var exception = Assert.Throws<NegativesNotAllowedException>((Action) TestCode);

            Assert.Contains("-1", exception.Message);
            Assert.Contains("-4", exception.Message);
            Assert.DoesNotContain("7", exception.Message);
        }

        [Theory]
        [InlineData(5, "5,1001")]
        [InlineData(4, "1002,4")]
        [InlineData(3, "1003,3,1004")]
        public void IgnoreNumbersAbove1000(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1005, "5,1000")]
        [InlineData(1003, "1000,3")]
        public void SumNumbersCorrectly_GivenNumbersUpTo1000(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, "//[|||]\n1|||2|||3")]
        public void AllowMulticharacterDelimiters_GivenSquareBraces(int expected, string input)
        {
            int result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
    }
}
