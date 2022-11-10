namespace InteractionWithDynamoDb.Lambda.Models;

public class Order : Entity
{
    public Guid CustomerId  { get; set; }
}