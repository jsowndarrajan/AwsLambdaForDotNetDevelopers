namespace AwsServerless.Environment;

public interface IEnvironment
{
    string? GetEnvironmentVariable(string variable);

    string? GetAwsRegion();

    string? GetAppEnvironment();
}