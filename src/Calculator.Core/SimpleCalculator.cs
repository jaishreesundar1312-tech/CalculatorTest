namespace Calculator.Core;

/// <summary>
/// Concrete implementation of <see cref="ISimpleCalculator"/>.
/// </summary>
/// <remarks>
/// Assumption: the interface uses <c>int</c>, so results are bounded by
/// <see cref="int.MinValue"/>/<see cref="int.MaxValue"/>. To avoid silent
/// wrap-around producing surprising results, arithmetic is performed in a
/// <c>checked</c> context so that overflow surfaces as an
/// <see cref="OverflowException"/> rather than a wrong answer.
/// </remarks>
public class SimpleCalculator : ISimpleCalculator
{
    public int Add(int start, int amount)
    {
        checked
        {
            return start + amount;
        }
    }

    public int Subtract(int start, int amount)
    {
        checked
        {
            return start - amount;
        }
    }
}
