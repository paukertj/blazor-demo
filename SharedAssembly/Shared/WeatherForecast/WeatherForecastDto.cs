namespace Shared.WeatherForecast
{
    public class WeatherForecastDto
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }
}
