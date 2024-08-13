using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.TextToAudio;

namespace ConsoleAppSK.Examples;

public static class E07_AudiotTextToSpeech
{
    private const string _text = "Overwatering is a common issue for those taking care of houseplants. To prevent it, it is crucial to allow the soil to dry out between waterings. Instead of watering on a fixed schedule, consider using a moisture meter to accurately gauge the soil's wetness. Should the soil retain moisture, it is wise to postpone watering for a couple more days. When in doubt, it is often safer to water sparingly and maintain a less-is-more approach.";

    private static readonly string _outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "text-to-speech.mp3");

    public static async Task Run()
    {
        // Once the APIs for this feature are stable, the experimental attribute will be removed

#pragma warning disable SKEXP0010, SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        Kernel kernel = Kernel.CreateBuilder()
            .AddOpenAITextToAudio(OpenAIConfig.Models.TextToSpeech, OpenAIConfig.ApiKey)
            .Build();

        var textToAudioService = kernel.GetRequiredService<ITextToAudioService>();

        AudioContent audioContent = await textToAudioService.GetAudioContentAsync(_text);
#pragma warning restore SKEXP0010, SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates.

        using FileStream stream   = File.OpenWrite(_outputFilePath);

        await stream.WriteAsync(audioContent.Data!.Value);

        Console.Out.AI().WriteLine("Generated Speech from Text: {0}", _outputFilePath);

        Console.Out.ResetColor().WriteLine("--- End of E07_AudiotTextToSpeech ---");
    }
}
