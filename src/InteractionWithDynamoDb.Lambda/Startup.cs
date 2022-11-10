using AwsServerless.DynamoDB;
using Microsoft.Extensions.DependencyInjection;

namespace InteractionWithDynamoDb.Lambda;

public class Startup
{
    private readonly IServiceCollection _serviceCollection;

    public Startup()
    {
        _serviceCollection = new ServiceCollection();
    }

    public ServiceProvider ConfigureServices()
    {
        _serviceCollection.AddDynamoDb();
        return _serviceCollection.BuildServiceProvider();
    }
}