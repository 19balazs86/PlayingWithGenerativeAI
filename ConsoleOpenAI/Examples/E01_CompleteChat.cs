using OpenAI.Chat;
using System.ClientModel;

namespace ConsoleOpenAI.Examples;

// Examples: https://github.com/openai/openai-dotnet/tree/main/examples/Chat
public static class E01_CompleteChat
{
    public static async Task Run()
    {
        var chatClient = new ChatClient(OpenAIConfig.Models.GPT_4o_Mini, OpenAIConfig.ApiKey);

        // --> #1 CompleteChat
        {
            Console.Out.User().WriteLine("You: 'Say hello!'");

            ChatCompletion completion = await chatClient.CompleteChatAsync("Say hello!");

            Console.Out.AI().WriteLine($"AI: {completion}");
        }

        // --> #2 CompleteChat Streaming
        {
            Console.Out.User().WriteLine("You: 'Who are you?'");

            AsyncResultCollection<StreamingChatCompletionUpdate> updates = chatClient.CompleteChatStreamingAsync("Who are you?");

            Console.Out.AI().Write($"AI: ");

            await foreach (StreamingChatCompletionUpdate update in updates)
            {
                foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
                {
                    Console.Write(updatePart.Text);
                }
            }
        }

        Console.Out.ResetColor().WriteLine("\n--- End of E01_CompleteChat ---");
    }
}
