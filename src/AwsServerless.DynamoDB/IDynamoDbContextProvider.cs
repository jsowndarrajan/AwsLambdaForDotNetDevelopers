using Amazon.DynamoDBv2.DataModel;

namespace AwsServerless.DynamoDB;

public interface IDynamoDbContextProvider
{
    IDynamoDBContext GetDynamoDbContext();
}