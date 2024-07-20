using OpenAI;
using OpenAI.Images;

namespace ConsoleOpenAI.Examples;

// Examples for image generation/edit/variant
// - https://github.com/openai/openai-dotnet/tree/main/examples/Images
// - Mohamad Lawand: https://youtu.be/n9QRLH6eL4I
public static class E04_TextToImage
{
    private const string _prompt = "A dog flying over the a house";

    public static async Task Run(OpenAIClient openAIClient)
    {
        ImageClient imageClient = openAIClient.GetImageClient(OpenAIConfig.Models.Image_Dall_E_3);

        var options = new ImageGenerationOptions
        {
            Quality        = GeneratedImageQuality.Standard,
            Size           = GeneratedImageSize.W1024xH1024,
            Style          = GeneratedImageStyle.Natural,
            ResponseFormat = GeneratedImageFormat.Uri // Bytes
        };

        GeneratedImage generatedImage = await imageClient.GenerateImageAsync(_prompt, options);

        // BinaryData bytes = generatedImage.ImageBytes;

        Console.WriteLine($"GeneratedImage: {generatedImage.ImageUri}");

        Console.WriteLine("--- End of E04_TextToImage ---");
    }
}
