using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AwsServerless.CloudWatch.Serilog;
using HttpMultipartParser;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FunctionUrlWithMultipartFormData.Lambda;

public class FunctionHandler
{
    private readonly ILogger<FunctionHandler> _logger;

    public FunctionHandler()
    {
        var serviceProvider = new Startup().ConfigureServices();
        _logger = serviceProvider.GetService<ILogger<FunctionHandler>>()!;
    }

    public async Task<string> Handle(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext lambdaContext)
    {
        CorrelationId.Set(lambdaContext.AwsRequestId);

        var multipartFormData = Convert.FromBase64String(request.Body);
        _logger.LogInformation($"Form Data: {request.Body}");

        var memoryStream = new MemoryStream(multipartFormData);
        var parser = await MultipartFormDataParser.ParseAsync(memoryStream);

        var username = parser.GetParameterValue("username");
        _logger.LogInformation($"Username: {username}");

        var file = parser.Files.First();
        _logger.LogInformation($"FileName: {file.FileName}");
        _logger.LogInformation($"FileStream Length: {file.Data.Length}");

        return "Multipart form-data processed successfully";
    }
}
