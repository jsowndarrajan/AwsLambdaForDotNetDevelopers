using Amazon.DynamoDBv2.DataModel;
using AwsServerless.Environment;

namespace AwsServerless.DynamoDB
{
    public class DynamoDbContextProvider : IDynamoDbContextProvider
    {
        private readonly IAmazonDynamoDbProvider _amazonDynamoDbProvider;
        private readonly IEnvironment _environment;

        public DynamoDbContextProvider(
            IAmazonDynamoDbProvider amazonDynamoDbProvider,
            IEnvironment environment)
        {
            _amazonDynamoDbProvider = amazonDynamoDbProvider;
            _environment = environment;
        }

        public IDynamoDBContext GetDynamoDbContext()
        {
            var amazonDynamoDb = _amazonDynamoDbProvider.GetAmazonDynamoDb();

            return new DynamoDBContext(amazonDynamoDb, new DynamoDBContextConfig
            {
                TableNamePrefix = $"{_environment.GetAppEnvironment()}-"
            });
        }
    }
}
