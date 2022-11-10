using Amazon.DynamoDBv2;

namespace AwsServerless.DynamoDB;

public interface IAmazonDynamoDbProvider
{
    IAmazonDynamoDB GetAmazonDynamoDb();
}