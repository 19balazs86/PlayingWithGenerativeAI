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

        }

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline
        {
            app.MapWeatherForecastEndpoints();
        }

        app.Run();
    }
}
