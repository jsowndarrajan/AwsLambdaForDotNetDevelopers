using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Core;
using Amazon.Lambda.Model;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace TimeoutExperiment.CreateOrder;

public class FunctionHandler
{
   public async Task<string> Handle(CreateOrderCommand createOrderCommand, ILambdaContext context)
    {
        context.Logger.LogInformation($"Request: {JsonConvert.SerializeObject(createOrderCommand)}");
        var lambdaClient = new AmazonLambdaClient(RegionEndpoint.USEast1);
        var invokeRequest = new InvokeRequest
        {
            FunctionName = "demo-timeout-lambdaB",
            InvocationType = InvocationType.RequestResponse,
            Payload = JsonConvert.SerializeObject(createOrderCommand)
        };
        var processPaymentResponse = await lambdaClient.InvokeAsync(
            invokeRequest,
            new CancellationTokenSource(createOrderCommand.TimeoutInMilliseconds).Token);
        context.Logger.LogInformation($"Response: {JsonConvert.SerializeObject(processPaymentResponse)}");
        
        return await new StreamReader(processPaymentResponse.Payload).ReadToEndAsync();
    }
}
