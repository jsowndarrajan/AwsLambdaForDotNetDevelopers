using Microsoft.Extensions.DependencyInjection;

namespace AwsServerless.Environment;

public static class ServiceCollectionExtension
{
    public static void AddEnvironment(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEnvironment, EnvironmentDecorator>();
    }
}