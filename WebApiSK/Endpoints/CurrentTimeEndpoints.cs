using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.ComponentModel;

namespace WebApiSK.Endpoints;

// Plugin examples: https://github.com/microsoft/semantic-kernel/blob/main/dotnet/samples/GettingStarted/Step2_Add_Plugins.cs
public static class CurrentTimeEndpoints
{
    private static readonly OpenAIPromptExecutionSettings _promptExecutionSettings = new()
    {
        ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
    };

    public static void MapCurrentTimeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/current-time", getCurrentTime);
    }

    public static IKernelBuilderPlugins AddCurrentTimePlugin(this IKernelBuilderPlugins plugins)
    {
        //IEnumerable<KernelFunction> functions =
        //[
        //    KernelFunctionFactory.CreateFromMethod(
        //        method: () => DateTime.Now,
        //        functionName: "get_time",
        //        description: "Get the current date and time")
        //];

        //return plugins.AddFromFunctions("time_plugin", functions);

        return plugins.AddFromType<CurrentTimePlugin>("time_plugin"); // Registered as singleton
    }

    private static async Task<string> getCurrentTime(Kernel kernel, IChatCompletionService chatCompletionService, CancellationToken ct)
    {
        // Instead of a plugin, we can use "Pre-fetched Data Retrieval" by adding a system message with the current time

        var chatHistory = new ChatHistory(/*$"Current date and time in local: '{DateTime.Now}'"*/);

        chatHistory.AddUserMessage("Short description of the current time");

        ChatMessageContent result = await chatCompletionService.GetChatMessageContentAsync(chatHistory, _promptExecutionSettings, kernel, ct);

        return result.Content!;
    }
}

public sealed class CurrentTimePlugin(ILogger<CurrentTimePlugin> _logger)
{
    [KernelFunction("get_time")]
    [Description("Get the current local date and time")]
    [return: Description("DateTime object")]
    public DateTime GetCurrentTime()
    {
        _logger.LogInformation("Getting the current time from the plugin");

        return DateTime.Now;
    }
}