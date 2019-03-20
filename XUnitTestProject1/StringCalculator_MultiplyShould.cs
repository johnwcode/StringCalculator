using System;
using StringCalculator;
using Xunit;

namespace XUnitTestProject1
{
    public class StringCalculator_MultiplyShould
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(24, "24")]
        public void ReturnTheNumber_GivenSingleNumberString(int expected, string input)
        {
            int result = Calculator.Multiply(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "1,1")]
        [InlineData(0, "0,2")]
        [InlineData(22, "11,2")]
        public void ReturnMultipliedNumbers_GivenTwoNumbers(int expected, string input)
        {
            int result = Calculator.Multiply(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(24, "1,1,2,3,4")]
        [InlineData(16, "1,2,2,2,2")]
        [InlineData(506, "11,2,23")]
        public void ReturnMultipledNumbers_GivenMoreThanTwoNumbers(int expected, string input)
        {
            int result = Calculator.Multiply(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(110, "11\n2,5")]
        [InlineData(968, "22\n2\n22")]
        public void ReturnMultipliedNumbers_GivenNewLineSeparators(int expected, string input)
        {
            int result = Calculator.Multiply(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, "//;\n1;2")]
        public void ReturnMultipliedNumbers_GivenCustomDelimitedNumbers(int expected, string input)
        {
            int result = Calculator.Multiply(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThrowException_GivenNegativeNumbers()
        {
            void TestCode() => Calculator.Multiply("-1,-4,7");
            var exception = Assert.Throws<NegativesNotAllowedException>((Action) TestCode);

            Assert.Contains("-1", exception.Message);
            Assert.Contains("-4", exception.Message);
            Assert.DoesNotContain("7", exception.Message);
        }

        [Theory]
        [InlineData(5, "5,1001")]
        [InlineData(4, "1002,4")]
        [InlineData(3, "1003,3,1004")]
        [InlineData(6, "1001, 3, 1002, 2, 1")]
        public void IgnoreNumbersAbove1000(int expected, string input)
        {
            int result = Calculator.Multiply(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5000, "5, 1000")]
        [InlineData(3000, "1000,3")]
        public void MultiplyNumbersCorrectly_GivenNumbersUpTo1000(int expected, string input)
        {
            int result = Calculator.Multiply(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, "//[|||]\n1|||2|||3")]
        public void AllowMulticharacterDelimiters_GivenSquareBraces(int expected, string input)
        {
            int result = Calculator.Multiply(input);

            Assert.Equal(expected, result);
        }
    }
}
