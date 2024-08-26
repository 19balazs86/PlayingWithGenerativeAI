namespace Shared;

public static class Settings
{
    public static class OpenAI
    {
        public static class Models
        {
            public const string GPT_4o            = "gpt-4o";
            public const string GPT_4o_Mini       = "gpt-4o-mini";
            public const string Embedding_3_Small = "text-embedding-3-small";
            public const string Image_Dall_E_3    = "dall-e-3";
            public const string AudioWhisper      = "whisper-1";
            public const string TextToSpeech      = "tts-1";
        }

        // Create the API key: https://platform.openai.com
        public static string ApiKey => Environment.GetEnvironmentVariable("OpenAI__ApiKey")
            ?? throw new NullReferenceException("Missing environment variable: OpenAI__ApiKey");
    }
}
