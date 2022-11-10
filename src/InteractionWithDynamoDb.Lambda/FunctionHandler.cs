using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace InteractionWithDynamoDb.Lambda;

public class FunctionHandler
{
    public string Handle(string input, ILambdaContext context)
    {
        return input.ToUpper();
    }
}
