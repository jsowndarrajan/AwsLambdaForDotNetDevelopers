namespace AwsServerless.Environment;

public class EnvironmentDecorator : IEnvironment
{
    public string? GetEnvironmentVariable(string variable)
    {
        return System.Environment.GetEnvironmentVariable(variable);
    }

    public string? GetAwsRegion()
    {
        const string awsRegion = "AWS_REGION";
        return GetEnvironmentVariable(awsRegion);
    }

    public string? GetAppEnvironment()
    {
        const string awsRegion = "APP_ENVIRONMENT";
        return GetEnvironmentVariable(awsRegion);
    }
}