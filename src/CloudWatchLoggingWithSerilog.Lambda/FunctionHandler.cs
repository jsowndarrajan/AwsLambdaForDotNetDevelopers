using Amazon.Lambda.Core;
using CloudWatchLoggingWithSerilog.Lambda.Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CloudWatchLoggingWithSerilog.Lambda;

public class FunctionHandler
{
    private readonly ILogger<FunctionHandler> _logger;

    public FunctionHandler()
    {
        var serviceProvider = new Startup().ConfigureServices();
        _logger = serviceProvider.GetService<ILogger<FunctionHandler>>()!;
    }

    public string? Handle(string input, ILambdaContext context)
    {
        CorrelationId.Set(context.AwsRequestId);

        try
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new NullReferenceException("Input value should not be null or empty");
            }

            switch (input.ToLower())
            {
                case "debug":
                    _logger.LogDebug("Input value: {input}", input);
                    break;
                case "information":
                    _logger.LogInformation("Input value: {input}", input);
                    break;
                case "warning":
                    _logger.LogWarning("Input value: {input}", input);
                    break;
            }

            var output = input.ToUpper();
            _logger.LogInformation("output: {output}", output);

            return output;
        }
        catch (Exception ex)
        {
            _logger.LogError("Unhandled exception without json conversion {ex}", ex);
            _logger.LogCritical("Unhandled critical exception with json conversion {@ex}", ex);
        }

        return default;
    }
}
