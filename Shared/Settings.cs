using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Shared;

public static class Settings
{
    private static readonly Lazy<IConfiguration> _lazyConfig = new Lazy<IConfiguration>(lazyConfigFactory);

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

        public static string ApiKey { get; } = getValue("SettingsAI:OpenAI:ApiKey");
    }

    public static class AzureAI
    {
        public static class Deployments
        {
            public const string GPT_4o_Mini = "gpt-4o-mini-deployment";
        }

        public static string Endpoint { get; } = getValue("SettingsAI:AzureAI:Endpoint");

        public static string ApiKey { get; } = getValue("SettingsAI:AzureAI:ApiKey");
    }

    private static string getValue(string key)
    {
        return _lazyConfig.Value[key] ?? throw new NullReferenceException($"Missing configuration: '{key}'");
    }

    private static IConfiguration lazyConfigFactory()
    {
        Assembly assembly = Assembly.GetEntryAssembly()
            ?? throw new NullReferenceException("There was no EntryAssembly");

        return new ConfigurationBuilder().AddUserSecrets(assembly).Build();
    }
}
