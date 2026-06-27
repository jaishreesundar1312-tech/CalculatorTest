namespace Calculator.Core;

/// <summary>
/// Contract for a simple integer calculator, exactly as supplied
/// </summary>
public interface ISimpleCalculator
{
    int Add(int start, int amount);
    int Subtract(int start, int amount);
}
