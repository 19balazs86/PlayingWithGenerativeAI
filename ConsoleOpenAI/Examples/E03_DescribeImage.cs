using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace ConsoleOpenAI.Examples;

// Examples: https://github.com/openai/openai-dotnet/blob/main/examples/Chat/Example05_ChatWithVisionAsync.cs
public static class E03_DescribeImage
{
    public static async Task Run(OpenAIClient openAIClient)
    {
        ChatClient chatClient = openAIClient.GetChatClient(OpenAIConfig.Models.GPT_4o_Mini);

        var userChatMessage = createUserMessage();

        Console.Out.AI().Write($"AI image description: ");

        AsyncResultCollection<StreamingChatCompletionUpdate> updates = chatClient.CompleteChatStreamingAsync(userChatMessage);

        await updates.writeStreamingContent();

        Console.Out.ResetColor().WriteLine("\n--- End of E03_DescribeImage ---");
    }

    private static UserChatMessage createUserMessage()
    {
        using Stream imageStream = File.OpenRead(_imageFilePath);

        BinaryData imageBytes = BinaryData.FromStream(imageStream);

        var userChatMessage = ChatMessage.CreateUserMessage(
            ChatMessageContentPart.CreateTextMessageContentPart("Please describe the following image."),
            ChatMessageContentPart.CreateImageMessageContentPart(imageBytes, "image/jpeg"));
            // ChatMessageContentPart.CreateImageMessageContentPart(new Uri("...")));

        return userChatMessage;
    }

    private static async Task writeStreamingContent(this AsyncResultCollection<StreamingChatCompletionUpdate> updates)
    {
        await foreach (StreamingChatCompletionUpdate update in updates)
        {
            foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
            {
                Console.Write(updatePart.Text);

                await Task.Delay(50);
            }
        }
    }

    private static readonly string _imageFilePath = Path.Combine("Assets", "smile_computer_monitor.jpg");
}
