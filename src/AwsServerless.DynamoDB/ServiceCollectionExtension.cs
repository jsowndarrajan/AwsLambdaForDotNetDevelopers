using AwsServerless.CloudWatch.Serilog;
using AwsServerless.Environment;
using Microsoft.Extensions.DependencyInjection;

namespace AwsServerless.DynamoDB;

public static class ServiceCollectionExtension
{
    public static void AddDynamoDb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddEnvironment();
        serviceCollection.AddSerilog();

        serviceCollection.AddScoped<IAmazonDynamoDbProvider, AmazonDynamoDbProvider>();
        serviceCollection.AddScoped<IDynamoDbContextProvider, DynamoDbContextProvider>();
        serviceCollection.AddScoped(sp =>
        {
            var dbContextProvider = sp.GetRequiredService<IDynamoDbContextProvider>();
            return dbContextProvider.GetDynamoDbContext();
        });
    }
}