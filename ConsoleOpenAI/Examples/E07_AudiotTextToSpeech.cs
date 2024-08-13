using OpenAI;
using OpenAI.Audio;

namespace ConsoleOpenAI.Examples;

// Examples: https://github.com/openai/openai-dotnet/tree/main/examples/Audio
public static class E07_AudiotTextToSpeech
{
    private const string _text = "Overwatering is a common issue for those taking care of houseplants. To prevent it, it is crucial to allow the soil to dry out between waterings. Instead of watering on a fixed schedule, consider using a moisture meter to accurately gauge the soil's wetness. Should the soil retain moisture, it is wise to postpone watering for a couple more days. When in doubt, it is often safer to water sparingly and maintain a less-is-more approach.";

    private static readonly string _outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "text-to-speech.mp3");

    public static async Task Run(OpenAIClient openAIClient)
    {
        AudioClient audioClient = openAIClient.GetAudioClient(OpenAIConfig.Models.TextToSpeech);

        BinaryData speechBinaryData = await audioClient.GenerateSpeechFromTextAsync(_text, GeneratedSpeechVoice.Alloy);

        using FileStream stream = File.OpenWrite(_outputFilePath);

        await speechBinaryData.ToStream().CopyToAsync(stream);

        Console.Out.AI().WriteLine("Generated Speech from Text: {0}", _outputFilePath);

        Console.Out.ResetColor().WriteLine("--- End of E07_AudiotTextToSpeech ---");
    }
}
