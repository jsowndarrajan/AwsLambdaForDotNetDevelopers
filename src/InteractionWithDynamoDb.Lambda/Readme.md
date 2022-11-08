# Interaction with DynamoDB
This is a sample lambda function that demonstrates how to interact with DynamoDB using C#.NET

## Prerequisite
The following tools are required to execute this lambda function in local
* Visual Studio 2022 or other equivalent IDEs
* Docker Desktop (Linux)

## Local Setup
In order to execute this project on your machine, you must first install both DynamoDB and Mock lambda test tool.

### Dynamo DB
In order to setup the DynamoDB instance in local, run the following command on this project directory.

>docker-compose up

Note that the local DynamoDB can be accessed via the port # `8000`

### Mock lambda test tool
The mock lambda test tool is required to run the lambda function in local. If you haven't it earlier on your machine, then run the following command:

> dotnet tool install -g Amazon.Lambda.TestTool-6.0

This lambda test tool provides functionality similar to the quick F5 debugging experience.