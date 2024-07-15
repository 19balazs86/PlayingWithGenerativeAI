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
            services.addAndConfigureKernel();
        }

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline
        {
            app.MapWeatherForecastEndpoints();
        }

        app.Run();
    }

    private static void addAndConfigureKernel(this  IServiceCollection services)
    {
        services.AddKernel();

        services.AddOpenAIChatCompletion(OpenAIConfig.Models.GPT_3_5_Turbo, OpenAIConfig.ApiKey);
    }
}
