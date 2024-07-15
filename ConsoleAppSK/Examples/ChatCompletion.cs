using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ConsoleAppSK.Examples;

public static class ChatCompletion
{
    public static async Task Run()
    {
        ConsoleColor defaultConsoleColor = Console.ForegroundColor;

        IKernelBuilder builder      = Kernel.CreateBuilder();
        IServiceCollection services = builder.Services;

        // Add services to the container
        {
            services.AddOpenAIChatCompletion(OpenAIConfig.Models.GPT_3_5_turbo, OpenAIConfig.ApiKey);
        }

        Kernel kernel = builder.Build();

        string systemMessage = getSystemMessage();

        var chatHistory = new ChatHistory(systemMessage);

        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        while (true)
        {
            string prompt = getUserPrompt();

            if ("q" == prompt)
            {
                break;
            }

            chatHistory.AddUserMessage(prompt);

            string assistantMessage = string.Empty;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("AI: ");

            await foreach (var content in chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory))
            {
                Console.Write(content.Content);

                assistantMessage += content.Content;

                await Task.Delay(100);
            }

            Console.WriteLine();

            chatHistory.AddAssistantMessage(assistantMessage);
        }

        Console.ForegroundColor = defaultConsoleColor;
        Console.WriteLine("\n--- End of ChatCompletion ---");
    }

    private static string getSystemMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("AI: Who am I?");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("You: ");
        string? systemMessage = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(systemMessage))
        {
            systemMessage = "You are a simple AI assistant";

            Console.Write(systemMessage);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nAI: How can I help?");

        return systemMessage;
    }

    private static string getUserPrompt()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write("You: ");

        string? prompt = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(prompt))
        {
            prompt = "Could you tell me a short joke?";

            Console.WriteLine(prompt);
        }

        return prompt;
    }
}
