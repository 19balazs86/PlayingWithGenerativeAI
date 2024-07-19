using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace ConsoleAppSK.Examples;

public static class E01_KernelInvokePrompt
{
    public static async Task Run(string prompt)
    {
        IKernelBuilder builder      = Kernel.CreateBuilder();
        IServiceCollection services = builder.Services;

        // builder.AddAzureOpenAIChatCompletion(...); // AzureOpenAI
        // builder.AddOpenAIChatCompletion(...); // This works the same as builder.Services.AddOpenAI

        // Add services to the container
        {
            services.AddOpenAIChatCompletion(OpenAIConfig.Models.GPT_4o_Mini, OpenAIConfig.ApiKey);

            // You can add logging as well
            // services.AddLogging(loggingBuilder => loggingBuilder.AddConsole().SetMinimumLevel(LogLevel.Trace));
        }

        Kernel kernel = builder.Build();

        // --> Invoke #1
        // await foreach (StreamingKernelContent content in kernel.InvokePromptStreamingAsync(prompt))
        await foreach (string content in kernel.InvokePromptStreamingAsync<string>(prompt))
        {
            Console.Out.WriteAI(content);
        }

        // --> Invoke #2
        Console.WriteLine("\n--- Summarize---");

        var kernelArguments = new KernelArguments { ["input"] = _longTextToSummarize };

        Console.Out.WriteLineAI(await kernel.InvokePromptAsync<string>(_promptWithArgument, kernelArguments));

        // --> Invoke #3
        Console.WriteLine("\n--- Summarize ---");

        // KernelFunction summarizeFunction = KernelFunctionFactory.CreateFromPrompt(_promptWithArgument);
        KernelFunction summarizeFunction = kernel.CreateFunctionFromPrompt(_promptWithArgument);

        Console.Out.WriteLineAI(await kernel.InvokeAsync<string>(summarizeFunction, kernelArguments));

        Console.WriteLine("--- End of InvokePrompt ---");
    }

    private const string _promptWithArgument =
        """
        One line TL;DR with the fewest words:

        '{{$input}}'
        """;

    private const string _longTextToSummarize =
        """
        1. An object at rest remains at rest, and an object in motion remains in motion at constant speed and in a straight line unless acted on by an unbalanced force.
        2. The acceleration of an object depends on the mass of the object and the amount of force applied.
        3. Whenever one object exerts a force on another object, the second object exerts an equal and opposite on the first.
        """;
}
