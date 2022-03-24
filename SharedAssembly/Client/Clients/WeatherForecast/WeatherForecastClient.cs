using Flurl;
using Client.Extensions;
using Client.Settings;
using Microsoft.Extensions.Options;
using Shared.WeatherForecast;
using Flurl.Http;

namespace Client.Clients.WeatherForecast
{
    internal class WeatherForecastClient : IWeatherForecastClient
    {
        private readonly ConnectionSettings _connectionSettings;

        public WeatherForecastClient(IOptions<ConnectionSettings> connectionSettings)
        {
            _connectionSettings = connectionSettings.Value;
        }

        public async Task<IEnumerable<WeatherForecastDto>> GetWeatherForecastAsync()
        {
            string contract = UrlHelper.GetController<IWeatherForecastContract>();

            return await _connectionSettings
                .ApiUrl
                .AppendPathSegment(contract)
                .GetJsonAsync<IEnumerable<WeatherForecastDto>>();
        }
    }
}
