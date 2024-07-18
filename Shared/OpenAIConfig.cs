namespace Shared;

public static class OpenAIConfig
{
    public static class Models
    {
        public const string GPT_3_5_Turbo     = "gpt-3.5-turbo-0125";
        public const string GPT_4o            = "gpt-4o";
        public const string GPT_4o_Mini       = "gpt-4o-mini";
        public const string Embedding_3_Small = "text-embedding-3-small";
    }

    // Create the API key: https://platform.openai.com
    public static string ApiKey => Environment.GetEnvironmentVariable("OpenAI__ApiKey")
        ?? throw new NullReferenceException("Missing environment variable: OpenAI__ApiKey");
}
