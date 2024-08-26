using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ConsoleAppSK.Examples;

public static class E02_ChatWithHistory
{
    public static async Task Run()
    {
        Kernel kernel = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(Settings.OpenAI.Models.GPT_4o_Mini, Settings.OpenAI.ApiKey)
            .Build();

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

            Console.Out.AI().Write("AI: ");

            await foreach (var content in chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory))
            {
                Console.Out.AI().Write(content.Content);

                assistantMessage += content.Content;

                await Task.Delay(50);
            }

            Console.WriteLine();

            chatHistory.AddAssistantMessage(assistantMessage);
        }

        Console.Out.ResetColor().WriteLine("\n--- End of ChatCompletion ---");
    }

    private static string getSystemMessage()
    {
        Console.Out.AI().WriteLine("AI: Who am I?");

        Console.Out.User().Write("You: ");

        string? systemMessage = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(systemMessage))
        {
            systemMessage = "You are a simple AI assistant";

            Console.Write(systemMessage);
        }

        Console.Out.AI().WriteLine("\nAI: How can I help?");

        return systemMessage;
    }

    private static string getUserPrompt()
    {
        Console.Out.User().Write("You: ");

        string? prompt = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(prompt))
        {
            prompt = "Could you tell me a short joke?";

            Console.WriteLine(prompt);
        }

        return prompt;
    }
}
