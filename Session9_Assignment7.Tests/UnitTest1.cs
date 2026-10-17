using System;
using Xunit;
using Session9_Assignment7; // اسم مشروع الكونسول الخاص بكِ

namespace Session9_Assignment7.Tests
{
    public class FineCalculatorTests
    {
        private readonly FineCalculator _calculator;

        // Initialize FineCalculator instance in constructor (stored in a readonly field)
        public FineCalculatorTests()
        {
            _calculator = new FineCalculator();
        }

        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            int a = 10;
            int b = 5;
            int expected = 15;

            // Act
            int actual = _calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_ShouldReturnNotEqual()
        {
            // Arrange
            int a = 10;
            int b = 5;
            int unexpected = 20;

            // Act
            int actual = _calculator.Add(a, b);

            // Assert
            Assert.NotEqual(unexpected, actual);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            // Arrange
            int a = 20;
            int b = 8;
            int expected = 12;

            // Act
            int actual = _calculator.Subtract(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 5, 20)]
        [InlineData(-3, 4, -12)] // Negative number case requirement
        [InlineData(0, 7, 0)]
        public void Multiply_ShouldReturnCorrectResult(int a, int b, int expected)
        {
            // Act
            int actual = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 3, 15)]
        [InlineData(-2, 5, 0)]
        public void Multiply_ShouldReturnNotEqual(int a, int b, int unexpected)
        {
            // Act
            int actual = _calculator.Multiply(a, b);

            // Assert
            Assert.NotEqual(unexpected, actual);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        }
    }
}