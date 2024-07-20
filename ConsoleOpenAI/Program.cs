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

        await E02_ChatWithHistory.Run(openAIClient);

        // await E03_DescribeImage.Run(openAIClient);

        // await E04_TextToImage.Run(openAIClient);

        // await E05_EmbeddingSimilarity.Run(openAIClient);
    }
}
