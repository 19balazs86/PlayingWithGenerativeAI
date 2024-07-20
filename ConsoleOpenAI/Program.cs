using ConsoleOpenAI.Examples;
using OpenAI;

namespace ConsoleOpenAI;

public static class Program
{
    public static async Task Main(string[] args)
    {
        // You can use this client to create other clients, such as ChatClient
        var openAIClient = new OpenAIClient(OpenAIConfig.ApiKey);

        await E01_CompleteChat.Run(openAIClient);
    }
}
