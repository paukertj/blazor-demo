namespace Shared.WeatherForecast
{
    public interface IWeatherForecastContract
    {
        Task<IEnumerable<WeatherForecastDto>> GetWeatherForecastAsync();
    }
}
