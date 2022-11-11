using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwsServerless.CloudWatch.Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionUrlWithMultipartFormData.Lambda;

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