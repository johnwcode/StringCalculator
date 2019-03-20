using System;
using StringCalculator;
using Xunit;

namespace XUnitTestProject1
{
    public class StringCalculator_DivideShould
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(24, "24")]
        public void ReturnTheNumber_GivenSingleNumberString(int expected, string input)
        {
            int result = Calculator.Divide(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "1,1")]
        [InlineData(0, "0,2")]
        [InlineData(5, "10,2")]
        public void ReturnDividedNumbers_GivenTwoNumbers(int expected, string input)
        {
            int result = Calculator.Divide(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, "8,1,2,2,1")]
        [InlineData(4, "8,1,1,1,2")]
        [InlineData(6, "24,2,2")]
        public void ReturnDividedNumbers_GivenMoreThanTwoNumbers(int expected, string input)
        {
            int result = Calculator.Divide(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, "20\n2,5")]
        [InlineData(1, "20\n2\n10")]
        public void ReturnDividedNumbers_GivenNewLineSeparators(int expected, string input)
        {
            int result = Calculator.Divide(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, "//;\n2;1")]
        public void ReturnDividedNumbers_GivenCustomDelimitedNumbers(int expected, string input)
        {
            int result = Calculator.Divide(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ThrowException_GivenNegativeNumbers()
        {
            void TestCode() => Calculator.Divide("-1,-4,7");
            var exception = Assert.Throws<NegativesNotAllowedException>((Action)TestCode);

            Assert.Contains("-1", exception.Message);
            Assert.Contains("-4", exception.Message);
            Assert.DoesNotContain("7", exception.Message);
        }

        [Theory]
        [InlineData(5, "5,1001")]
        [InlineData(4, "1002,4")]
        [InlineData(3, "1003,3,1004")]
        [InlineData(3, "1001, 6, 1002, 2, 1")]
        public void IgnoreNumbersAbove1000(int expected, string input)
        {
            int result = Calculator.Divide(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, "5, 1000")]
        [InlineData(200, "1000,5")]
        public void DivideNumbersCorrectly_GivenNumbersUpTo1000(int expected, string input)
        {
            int result = Calculator.Divide(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, "//[|||]\n8|||2|||2")]
        public void AllowMulticharacterDelimiters_GivenSquareBraces(int expected, string input)
        {
            int result = Calculator.Divide(input);

            Assert.Equal(expected, result);
        }
    }
}
