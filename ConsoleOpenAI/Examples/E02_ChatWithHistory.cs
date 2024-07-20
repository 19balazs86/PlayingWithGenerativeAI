using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace ConsoleOpenAI.Examples;

public static class E02_ChatWithHistory
{
    public static async Task Run(OpenAIClient openAIClient)
    {
        List<ChatMessage> chatHistory = [getSystemMessage()];

        ChatClient chatClient = openAIClient.GetChatClient(OpenAIConfig.Models.GPT_4o_Mini);

        while (true)
        {
            string prompt = getUserPrompt();

            if ("q" == prompt)
            {
                break;
            }

            chatHistory.Add(ChatMessage.CreateUserMessage(prompt));

            string assistantMessage = string.Empty;

            Console.Out.AI().Write("AI: ");

            AsyncResultCollection<StreamingChatCompletionUpdate> updates = chatClient.CompleteChatStreamingAsync(chatHistory);

            await foreach (StreamingChatCompletionUpdate update in updates)
            {
                foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
                {
                    Console.Out.AI().Write(updatePart.Text);

                    assistantMessage += updatePart.Text;

                    await Task.Delay(50);
                }
            }

            Console.WriteLine();

            chatHistory.Add(ChatMessage.CreateAssistantMessage(assistantMessage));
        }

        Console.Out.ResetColor().WriteLine("--- End of E02_ChatWithHistory ---");
    }

    private static SystemChatMessage getSystemMessage()
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

        return ChatMessage.CreateSystemMessage(systemMessage);
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
