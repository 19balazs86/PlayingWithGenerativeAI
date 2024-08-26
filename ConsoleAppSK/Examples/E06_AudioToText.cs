using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AudioToText;

namespace ConsoleAppSK.Examples;

public static class E06_AudioToText
{
    private static readonly string _audioFilePath = Path.Combine("Assets", "audio-houseplant-care.mp3");

    public static async Task Run()
    {
        // Once the APIs for this feature are stable, the experimental attribute will be removed

#pragma warning disable SKEXP0010, SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        Kernel kernel = Kernel.CreateBuilder()
            .AddOpenAIAudioToText(Settings.OpenAI.Models.AudioWhisper, Settings.OpenAI.ApiKey)
            .Build();

        var audioToTextService = kernel.GetRequiredService<IAudioToTextService>();

        byte[] bytes = await File.ReadAllBytesAsync(_audioFilePath);

        var audioContent = new AudioContent(bytes, "audio/mpeg");

        TextContent textContent = await audioToTextService.GetTextContentAsync(audioContent);
#pragma warning restore SKEXP0010, SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates.

        Console.Out.AI().WriteLine("Transcription: {0}", textContent.Text);

        Console.Out.ResetColor().WriteLine("--- End of E06_AudioToText ---");
    }
}
