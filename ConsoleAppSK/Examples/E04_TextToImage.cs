using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.TextToImage;

namespace ConsoleAppSK.Examples;

public static class E04_TextToImage
{
    private const string _prompt = "A dog flying over the a house";

    public static async Task Run()
    {
        // Once the APIs for this feature are stable, the experimental attribute will be removed

#pragma warning disable SKEXP0010, SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        Kernel kernel = Kernel.CreateBuilder()
            .AddOpenAITextToImage(OpenAIConfig.ApiKey)
            .Build();

        var textToImageService = kernel.GetRequiredService<ITextToImageService>();

        string imageUrl = await textToImageService.GenerateImageAsync(_prompt, 1024, 1024);
#pragma warning restore SKEXP0010, SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates.

        Console.WriteLine(imageUrl);

        Console.WriteLine("\n--- End of TextToImage ---");
    }
}
