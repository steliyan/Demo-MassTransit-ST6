namespace Contracts
{
    public interface OrderPizzaMessage
    {
        string Type { get; }

        decimal Amount { get; }

        string CardNumber { get; }
    }
}