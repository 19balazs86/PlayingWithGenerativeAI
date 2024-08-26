using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ConsoleAppSK.Examples;

public static class E03_DescribeImage
{
    private static readonly Uri _imageUrl = new Uri("https://bestfriends.org/sites/default/files/resource_article_images/Introduce-cat-dog-Cappuccino-6650sak%255B1%255D.jpg");

    public static async Task Run()
    {
        Kernel kernel = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(Settings.OpenAI.Models.GPT_4o_Mini, Settings.OpenAI.ApiKey)
            .Build();

        var chatHistory = new ChatHistory("You are a friendly AI assistant that responds to questions about images");

        var contentItemCollection = new ChatMessageContentItemCollection
        {
            new TextContent("Could you briefly describe this image?"),
            new ImageContent(_imageUrl)
            //new ImageContent(File.ReadAllBytes(@"c:\....jpg"), "image/jpeg")
        };

        chatHistory.AddUserMessage(contentItemCollection);

        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        await foreach (var content in chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory))
        {
            Console.Out.AI().Write(content.Content);

            await Task.Delay(50);
        }

        Console.Out.ResetColor().WriteLine("\n--- End of DescribeImage ---");
    }
}
