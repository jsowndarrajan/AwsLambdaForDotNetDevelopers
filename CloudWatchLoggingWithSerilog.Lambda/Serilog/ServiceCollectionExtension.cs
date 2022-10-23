using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;

namespace CloudWatchLoggingWithSerilog.Lambda.Serilog
{
    public static class ServiceCollectionExtension
    {
        public static void AddSerilog(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddLogging(builder =>
            {
                var logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.With(new CorrelationIdEnricher())
                    .WriteTo.Console(new JsonFormatter())
                    .CreateLogger();

                builder.AddSerilog(logger);
            });
        }
    }
}
