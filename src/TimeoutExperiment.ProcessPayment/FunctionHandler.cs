using Amazon.Lambda.Core;
using AwsServerless.Shared.ValueObjects;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace TimeoutExperiment.ProcessPayment;

public class FunctionHandler
{
    public async Task<PaymentResponse> Handle(OrderCreated orderCreatedEvent, ILambdaContext context)
    {
        context.Logger.LogInformation($"Order created with Id: {orderCreatedEvent.OrderId}");

        var completedTask = await Task.WhenAny(ProcessPayment(), Task.Delay(((Minutes)orderCreatedEvent.TimeoutInMinutes).ToMilliseconds()));

        if (completedTask is Task<PaymentResponse> response)
        {
            var paymentResponse = await response;
            context.Logger.LogInformation($"Payment process completed with Id: {paymentResponse.PaymentId}");
            return paymentResponse;
        }

        throw new TimeoutException($"Payment process failed. Timeout Duration: {orderCreatedEvent.TimeoutInMinutes}");
    }

    private async Task<PaymentResponse> ProcessPayment()
    {
        await Task.Delay(new Minutes(2).ToMilliseconds());

        return await Task.FromResult(new PaymentResponse
        {
            PaymentId = Guid.NewGuid().ToString(),
            PaymentStatus = "SUCCESS"
        });
    }
}