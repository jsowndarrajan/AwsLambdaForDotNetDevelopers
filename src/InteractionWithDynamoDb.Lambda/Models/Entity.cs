namespace InteractionWithDynamoDb.Lambda.Models;

public abstract class Entity : IEntity
{
    public Guid Id { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}