using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Shared;

namespace ConsoleAppSK.Examples;

public static class KernelInvokePrompt
{
    public static async Task Run(string prompt)
    {
        IKernelBuilder builder      = Kernel.CreateBuilder();
        IServiceCollection services = builder.Services;

        // builder.AddAzureOpenAIChatCompletion(...); // AzureOpenAI
        // builder.AddOpenAIChatCompletion(...); // This works the same as builder.Services.AddOpenAI

        // Add services to the container
        {
            services.AddOpenAIChatCompletion(OpenAIConfig.Models.GPT_3_5_Turbo, OpenAIConfig.ApiKey);

            // You can add logging as well
            // services.AddLogging(loggingBuilder => loggingBuilder.AddConsole().SetMinimumLevel(LogLevel.Trace));
        }

        Kernel kernel = builder.Build();

        // await foreach (StreamingKernelContent content in kernel.InvokePromptStreamingAsync(prompt))
        await foreach (string content in kernel.InvokePromptStreamingAsync<string>(prompt))
        {
            Console.Write(content);
        }

        Console.WriteLine("\n--- End of InvokePrompt ---");
    }
}
