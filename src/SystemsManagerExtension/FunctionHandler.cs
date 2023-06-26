using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SystemsManagerExtension;

public class FunctionHandler
{
    private readonly string _getSystemsManagerUrl;
    private readonly string? _awsSession;

    public FunctionHandler()
    {
        var port = Environment.GetEnvironmentVariable("PARAMETERS_SECRETS_EXTENSION_HTTP_PORT");
        _getSystemsManagerUrl = $"http://localhost:{port}/systemsmanager/parameters/get";
        _awsSession = Environment.GetEnvironmentVariable("AWS_SESSION_TOKEN");
    }
    
    public async Task<string> Handle(string ssmParameterName, ILambdaContext context)
    {
        context.Logger.LogInformation($"SSM Parameter Name: {ssmParameterName}");

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Aws-Parameters-Secrets-Token", _awsSession);

        var ssmParameterValue = await client.GetAsync($"{_getSystemsManagerUrl}?name={ssmParameterName}")
            .Result
            .Content
            .ReadAsStringAsync();;

        context.Logger.LogInformation($"SSM Parameter Value: {ssmParameterValue}");

        return ssmParameterValue;
    }
}
