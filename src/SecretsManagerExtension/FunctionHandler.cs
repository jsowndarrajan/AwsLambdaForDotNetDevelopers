using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SecretsManagerExtension;

public class FunctionHandler
{
    private readonly string _getSecretsManagerUrl;
    private readonly string? _awsSession;

    public FunctionHandler()
    {
        var port = Environment.GetEnvironmentVariable("PARAMETERS_SECRETS_EXTENSION_HTTP_PORT");
        _getSecretsManagerUrl = $"http://localhost:{port}/secretsmanager/get";
        _awsSession = Environment.GetEnvironmentVariable("AWS_SESSION_TOKEN");
    }

    public async Task<string> Handle(string secretId, ILambdaContext context)
    {
        context.Logger.LogInformation($"Secret Id: {secretId}");

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Aws-Parameters-Secrets-Token", _awsSession);

        var secretValue = await client.GetAsync($"{_getSecretsManagerUrl}?secretId={secretId}")
                                      .Result
                                      .Content
                                      .ReadAsStringAsync();;

        context.Logger.LogInformation($"Secret Value: {secretValue}");

        return secretValue;
    }
}
