using StyleMate.Models;

namespace StyleMate.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse?> GetWeatherAsync(string city);
    }
}