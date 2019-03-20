using System;
using StringCalculator;
using Xunit;

namespace XUnitTestProject1
{
    public class StringCalculator_SubtractShould
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(24, "24")]
        public void ReturnTheNumber_GivenSingleNumberString(int expected, string input)
        {
            int result = Calculator.Subtract(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, "1,1")]
        [InlineData(-1, "1,2")]
        [InlineData(9, "11,2")]
        public void ReturnSubtractionOfNumbers_GivenTwoNumbers(int expected, string input)
        {
            int result = Calculator.Subtract(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-9, "1,1,2,3,4")]
        [InlineData(-7, "1,2,2,2,2")]
        [InlineData(-14, "11,2,23")]
        public void ReturnSubtractionOfNumbers_GivenMoreThanTwoNumbers(int expected, string input)
        {
            int result = Calculator.Subtract(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, "11\n2,5")]
        [InlineData(-2, "22\n2\n22")]
        public void ReturnSubtractionOfNumbers_GivenNewLineSeparators(int expected, string input)
        {
            int result = Calculator.Subtract(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, "//;\n1;2")]
        public void ReturnSubtractionOfNumbers_GivenCustomDelimitedNumbers(int expected, string input)
        {
            int result = Calculator.Subtract(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThrowException_GivenNegativeNumbers()
        {
            void TestCode() => Calculator.Subtract("-1,-4,7");
            var exception = Assert.Throws<NegativesNotAllowedException>((Action) TestCode);

            Assert.Contains("-1", exception.Message);
            Assert.Contains("-4", exception.Message);
            Assert.DoesNotContain("7", exception.Message);
        }

        [Theory]
        [InlineData(5, "5,1001")]
        [InlineData(4, "1002,4")]
        [InlineData(3, "1003,3,1004")]
        [InlineData(-1, "1001, 1, 1002, 2")]
        public void IgnoreNumbersAbove1000(int expected, string input)
        {
            int result = Calculator.Subtract(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-995, "5,1000")]
        [InlineData(997, "1000,3")]
        public void SubtractNumbersCorrectly_GivenNumbersUpTo1000(int expected, string input)
        {
            int result = Calculator.Subtract(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-4, "//[|||]\n1|||2|||3")]
        public void AllowMulticharacterDelimiters_GivenSquareBraces(int expected, string input)
        {
            int result = Calculator.Subtract(input);

            Assert.Equal(expected, result);
        }
    }
}
