namespace Calculator.Core;

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
