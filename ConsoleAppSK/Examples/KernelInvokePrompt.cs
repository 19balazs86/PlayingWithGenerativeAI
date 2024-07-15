using Microsoft.SemanticKernel;

namespace ConsoleAppSK.Examples;
public static class KernelInvokePrompt
{
    public static async Task Run(string prompt)
    {
        IKernelBuilder builder = Kernel.CreateBuilder();

        // builder.AddAzureOpenAIChatCompletion(...); // AzureOpenAI
        // builder.AddOpenAIChatCompletion(...); // This works the same as builder.Services.AddOpenAI

        builder.Services.AddOpenAIChatCompletion(OpenAIConfig.Models.GPT_3_5_turbo, OpenAIConfig.ApiKey);

        Kernel kernel = builder.Build();

        await foreach (StreamingKernelContent content in kernel.InvokePromptStreamingAsync(prompt))
        {
            Console.Write(content);
        }

        Console.WriteLine("\n--- End of InvokePrompt ---");
    }
}
