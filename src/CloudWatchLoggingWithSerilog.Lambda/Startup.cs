using CloudWatchLoggingWithSerilog.Lambda.Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace CloudWatchLoggingWithSerilog.Lambda
{
    public class Startup
    {
        private readonly IServiceCollection _serviceCollection;

        public Startup()
        {
            _serviceCollection = new ServiceCollection();
        }

        public ServiceProvider ConfigureServices()
        {
            _serviceCollection.AddSerilog();
            return _serviceCollection.BuildServiceProvider();
        }
    }
}
