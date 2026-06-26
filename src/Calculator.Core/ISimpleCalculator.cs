namespace Calculator.Core;

/// <summary>
/// Contract for a simple integer calculator, exactly as supplied
/// in the Renaissance Global programming challenge.
/// </summary>
public interface ISimpleCalculator
{
    int Add(int start, int amount);
    int Subtract(int start, int amount);
}
