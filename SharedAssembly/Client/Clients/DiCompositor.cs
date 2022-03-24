using Client.Clients.WeatherForecast;

namespace Client.Clients
{
    internal static class DiCompositor
    {
        internal static void AddClients(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IWeatherForecastClient, WeatherForecastClient>();
        }
    }
}
