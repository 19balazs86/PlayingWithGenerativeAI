using Microsoft.SemanticKernel;
using Shared;
using WebApiSK.Endpoints;

namespace WebApiSK;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        IServiceCollection services   = builder.Services;

        // Add services to the container
        {
            services.addSemanticKernel();
        }

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline
        {
            app.MapWeatherForecastEndpoints();

            app.MapCurrentTimeEndpoints();
        }

        app.Run();
    }

    private static void addSemanticKernel(this IServiceCollection services)
    {
        // https://learn.microsoft.com/en-us/semantic-kernel/concepts/plugins/adding-native-plugins?pivots=programming-language-csharp#inject-a-plugin-collection
        // Documentation says: Kernel is extremely lightweight, so creating a new one for each use as a transient is not a performance concern
        // You can omit the services.AddKernel(), add Kernel and KernelPluginCollection manually, if you need different life time

        // --> Add: OpenAI chat completion
        services.AddOpenAIChatCompletion(OpenAIConfig.Models.GPT_3_5_Turbo, OpenAIConfig.ApiKey); // Registered as singleton

        // --> Add: Kernel
        IKernelBuilder kernelBuilder = services.AddKernel(); // Kernel and KernelPluginCollection registered as transient

        // --> Add: Plugins
        kernelBuilder.Plugins.AddCurrentTimePlugin();
    }
}
