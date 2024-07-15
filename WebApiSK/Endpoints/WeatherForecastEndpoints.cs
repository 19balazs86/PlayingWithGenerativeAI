using Microsoft.SemanticKernel;

namespace WebApiSK.Endpoints;

public static class WeatherForecastEndpoints
{
    public static void MapWeatherForecastEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weather-forecast", getWeatherForecast);
    }

    private static async Task<WeatherForecast> getWeatherForecast(Kernel kernel)
    {
        int temperature = Random.Shared.Next(-20, 55);

        string summary = await kernel.InvokePromptAsync<string>($"Very short description of the weather at {temperature}°C") ?? "n/a";

        return new WeatherForecast
        {
            Date         = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = temperature,
            Summary      = summary
        };
    }
}

public sealed class WeatherForecast
{
    public required DateOnly Date { get; init; }

    public required int TemperatureC { get; init; }

    public required string Summary { get; init; }
}