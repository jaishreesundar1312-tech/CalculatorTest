using Calculator.Core;
using Xunit;

namespace Calculator.Tests;

public class SimpleCalculatorTests
{
    private readonly ISimpleCalculator _calculator = new SimpleCalculator();

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(2, 3, 5)]
    [InlineData(10, -4, 6)]      // adding a negative
    [InlineData(-5, -5, -10)]    // two negatives
    [InlineData(100, 0, 100)]    // identity
    public void Add_ReturnsExpectedSum(int start, int amount, int expected)
    {
        Assert.Equal(expected, _calculator.Add(start, amount));
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(5, 3, 2)]
    [InlineData(3, 5, -2)]       // result goes negative
    [InlineData(10, -4, 14)]     // subtracting a negative
    [InlineData(100, 0, 100)]    // identity
    public void Subtract_ReturnsExpectedDifference(int start, int amount, int expected)
    {
        Assert.Equal(expected, _calculator.Subtract(start, amount));
    }

    [Fact]
    public void Add_IsCommutative()
    {
        Assert.Equal(_calculator.Add(7, 11), _calculator.Add(11, 7));
    }

    [Fact]
    public void Add_OnOverflow_Throws()
    {
        Assert.Throws<OverflowException>(() => _calculator.Add(int.MaxValue, 1));
    }

    [Fact]
    public void Subtract_OnUnderflow_Throws()
    {
        Assert.Throws<OverflowException>(() => _calculator.Subtract(int.MinValue, 1));
    }
}
