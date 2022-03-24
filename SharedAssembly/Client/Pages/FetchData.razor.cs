using Shared.WeatherForecast;

namespace Client.Pages
{
    public partial class FetchData
    {
        private IEnumerable<WeatherForecastDto>? _forecasts;

        protected override async Task OnInitializedAsync()
        {
            _forecasts = await _weatherForecastClient
                .GetWeatherForecastAsync();
        }
    }
}
