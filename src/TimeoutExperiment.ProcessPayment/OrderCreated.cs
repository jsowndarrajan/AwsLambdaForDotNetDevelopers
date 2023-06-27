namespace TimeoutExperiment.ProcessPayment;

public class OrderCreated
{
    public Guid OrderId { get; set; }

    public int TimeoutInMinutes { get; set; }
}