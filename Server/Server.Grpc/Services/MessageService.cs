using Grpc.Core;
using Grpc.Messager;

namespace Server.Grpc.Services;

public sealed class MessageService : global::Grpc.Messager.MessageService.MessageServiceBase
{
    public override Task<Response> SendMessage(Message request, ServerCallContext context)
    {
        Console.WriteLine($"Received message from user {request.UserId}: {request.Message_}");
        return Task.FromResult(new Response { Code = 200 });
    }
}