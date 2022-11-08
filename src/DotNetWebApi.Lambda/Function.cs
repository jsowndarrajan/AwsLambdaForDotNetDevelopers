using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Hosting;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DotNetWebApi.Lambda;

public class Function : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
{ 
    protected override void Init(IWebHostBuilder builder)
    {
        builder.UseStartup<Startup>();
    }
}
