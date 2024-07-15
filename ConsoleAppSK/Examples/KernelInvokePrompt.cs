using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

namespace ConsoleAppSK.Examples;

public static class KernelInvokePrompt
{
    public static async Task Run(string prompt, bool enableLogging = false)
    {
        IKernelBuilder builder      = Kernel.CreateBuilder();
        IServiceCollection services = builder.Services;

        // builder.AddAzureOpenAIChatCompletion(...); // AzureOpenAI
        // builder.AddOpenAIChatCompletion(...); // This works the same as builder.Services.AddOpenAI

        // Add services to the container
        {
            services.AddOpenAIChatCompletion(OpenAIConfig.Models.GPT_3_5_turbo, OpenAIConfig.ApiKey);

            if (enableLogging)
            {
                services.AddLogging(loggingBuilder => loggingBuilder.AddConsole().SetMinimumLevel(LogLevel.Trace));
            }
        }

        Kernel kernel = builder.Build();

        await foreach (StreamingKernelContent content in kernel.InvokePromptStreamingAsync(prompt))
        {
            Console.Write(content);
        }

        Console.WriteLine("\n--- End of InvokePrompt ---");
    }
}
