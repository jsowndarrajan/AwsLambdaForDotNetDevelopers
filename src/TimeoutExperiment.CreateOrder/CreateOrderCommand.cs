namespace TimeoutExperiment.CreateOrder;

public class CreateOrderCommand
{
    public Guid OrderId { get; set; }

    public int TimeoutInMinutes { get; set; }

    internal int TimeoutInMilliseconds => TimeoutInMinutes * 60 * 1000;
}