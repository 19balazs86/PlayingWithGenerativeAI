using OpenAI;
using OpenAI.Audio;

namespace ConsoleOpenAI.Examples;

// Examples: https://github.com/openai/openai-dotnet/tree/main/examples/Audio
public static class E06_AudioToText
{
    private static readonly string _audioFilePath = Path.Combine("Assets", "audio-houseplant-care.mp3");

    public static async Task Run(OpenAIClient openAIClient)
    {
        AudioClient audioClient  = openAIClient.GetAudioClient(OpenAIConfig.Models.AudioWhisper);

        var options = new AudioTranscriptionOptions
        {
            ResponseFormat = AudioTranscriptionFormat.Simple
            // https://github.com/openai/openai-dotnet/blob/main/examples/Audio/Example03_VerboseTrascriptionAsync.cs
            // Granularities = AudioTimestampGranularities.Word | AudioTimestampGranularities.Segment
        };

        AudioTranscription transcription = await audioClient.TranscribeAudioAsync(_audioFilePath, options);

        Console.Out.AI().WriteLine("Transcription: {0}", transcription.Text);

        Console.Out.ResetColor().WriteLine("--- End of E06_AudioToText ---");
    }
}
