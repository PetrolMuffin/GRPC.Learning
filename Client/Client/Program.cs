// See https://aka.ms/new-console-template for more information
using Grpc.Messager;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;

// read server address and port from launchSettings.json

var configuration = new ConfigurationBuilder().AddJsonFile("launchSettings.json").Build();

var serverUrl = configuration["serverUrl"];
var serverPort = configuration["serverPort"];

var channel = GrpcChannel.ForAddress($"{serverUrl}:{serverPort}");
var client = new MessageService.MessageServiceClient(channel);

do
{
    var userId = GetUserId();
    var input = GetMessage();
    var message = new Message
    {
        UserId = userId,
        Message_ = input
    };
    
    var response = client.SendMessage(message);

    Console.WriteLine($"Response: {response.Code}");
} while (true);

int GetUserId()
{
    do
    {
        Console.WriteLine("Enter user id:");
        var input = Console.ReadLine();
        if (int.TryParse(input, out var userId))
        {
            return userId;
        }
    } while (true);
}

string? GetMessage()
{
    Console.WriteLine("Enter message:");
    return Console.ReadLine();
}