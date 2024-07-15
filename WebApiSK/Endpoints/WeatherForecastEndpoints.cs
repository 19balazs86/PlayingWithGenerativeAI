namespace WebApiSK.Endpoints;

public static class WeatherForecastEndpoints
{
    public static void MapWeatherForecastEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", getWeatherForecast);
    }

    private static async Task<WeatherForecast> getWeatherForecast()
    {
        await Task.Delay(500);

        return new WeatherForecast
        {
            Date         = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary      = WeatherForecast.Summaries[Random.Shared.Next(WeatherForecast.Summaries.Length)]
        };
    }
}

public sealed class WeatherForecast
{
    public static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public required DateOnly Date { get; init; }

    public required int TemperatureC { get; init; }

    public required string Summary { get; init; }
}