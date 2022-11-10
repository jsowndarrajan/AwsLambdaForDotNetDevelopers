using Amazon;
using Amazon.DynamoDBv2;
using AwsServerless.Environment;

namespace AwsServerless.DynamoDB;

public class AmazonDynamoDbProvider : IAmazonDynamoDbProvider
{
    private readonly IEnvironment _environment;

    public AmazonDynamoDbProvider(IEnvironment environment)
    {
        _environment = environment;
    }

    public IAmazonDynamoDB GetAmazonDynamoDb()
    {
        var awsRegion = _environment.GetAwsRegion();
        if (awsRegion is null)
        {
            throw new ArgumentNullException("AWS_REGION", "The AWS_REGION is not configured on the machine");
        }

        var regionEndpoint = RegionEndpoint.GetBySystemName(awsRegion);
        if (regionEndpoint is null)
        {
            throw new ArgumentException("The AWS_REGION on the machine is invalid");
        }

        return new AmazonDynamoDBClient(new AmazonDynamoDBConfig
        {
            RegionEndpoint = regionEndpoint
        });
    }
}