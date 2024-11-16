using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.Extensions.Configuration;
using StyleMate.Models;

namespace StyleMate.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherApi:ApiKey"];
            _baseUrl = configuration["WeatherApi:BaseUrl"];
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {
            var url = $"{_baseUrl}?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(jsonResponse, options);
                    return weatherResponse;
                }
                catch (JsonException ex) {
                    Console.WriteLine("Deserialization Error: " + ex.Message);
                    throw;
                }
            }

            return null;
        }
    }
}
