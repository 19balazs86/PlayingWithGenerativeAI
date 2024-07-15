namespace ConsoleAppSK;

public static class OpenAIConfig
{
    public static class Models
    {
        public const string GPT_3_5_turbo = "gpt-3.5-turbo-0125";
        public const string GPT_4o        = "gpt-4o";
    }

    // Create the API key: https://platform.openai.com
    public static string ApiKey => Environment.GetEnvironmentVariable("OpenAI__ApiKey")
        ?? throw new NullReferenceException("Missing environment variable: OpenAI__ApiKey");
}
