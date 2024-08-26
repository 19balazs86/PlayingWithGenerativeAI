using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace ConsoleOpenAI.Examples;

// Examples: https://github.com/openai/openai-dotnet/tree/main/examples/Chat
public static class E01_CompleteChat
{
    public static async Task Run(OpenAIClient openAIClient)
    {
        string prompt;

        // var chatClient = new ChatClient(OpenAIConfig.Models.GPT_4o_Mini, OpenAIConfig.ApiKey);

        ChatClient chatClient = openAIClient.GetChatClient(Settings.OpenAI.Models.GPT_4o_Mini);

        // --> #1 CompleteChat
        {
            Console.Out.User().WriteLine(prompt = "You: Say hello!");

            ChatCompletion completion = await chatClient.CompleteChatAsync(prompt);

            Console.Out.AI().WriteLine($"AI: {completion}");
        }

        // --> #2 CompleteChat with Streaming
        {
            Console.Out.User().WriteLine(prompt = "You: Who are you?");

            AsyncCollectionResult<StreamingChatCompletionUpdate> updates = chatClient.CompleteChatStreamingAsync(prompt);

            Console.Out.AI().Write($"AI: ");

            await foreach (StreamingChatCompletionUpdate update in updates)
            {
                foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
                {
                    Console.Write(updatePart.Text);

                    await Task.Delay(50);
                }
            }
        }

        Console.WriteLine();

        // --> #3 CompleteChat with MaxTokens
        // You can see example of FinishReason: https://github.com/openai/openai-dotnet/blob/main/examples/Chat/Example04_FunctionCallingStreaming.cs
        {
            Console.Out.User().WriteLine(prompt = "You: Tell me a LONG story about a dog.");

            var options = new ChatCompletionOptions { MaxTokens = 25 };
            ChatMessage[] messages = [ChatMessage.CreateUserMessage(prompt)];

            ChatCompletion completion = await chatClient.CompleteChatAsync(messages, options);

            Console.Out.AI().WriteLine($"AI: FinishReason: {completion.FinishReason}, TotalTokens: {completion.Usage.TotalTokens}");
        }

        Console.Out.ResetColor().WriteLine("--- End of E01_CompleteChat ---");
    }
}
