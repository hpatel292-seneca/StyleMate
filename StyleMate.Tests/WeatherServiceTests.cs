using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using StyleMate.Models;
using StyleMate.Services;
using Xunit;

namespace StyleMate.Tests
{
    public class WeatherServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly HttpClient _httpClient;
        private readonly WeatherService _weatherService;
        public WeatherServiceTests()
        {
            // Mock configuration settings
            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfiguration.Setup(c => c["WeatherApi:ApiKey"]).Returns("test_api_key");
            _mockConfiguration.Setup(c => c["WeatherApi:BaseUrl"]).Returns("http://mockapi/weather");

            // Mock HttpClient
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://mockapi/")
            };

            // Initialize WeatherService with mocks
            _weatherService = new WeatherService(_httpClient, _mockConfiguration.Object);
        }

        [Fact]
        public async Task GetWeatherAsync_ReturnsWeatherResponse_WhenApiResponseIsValid()
        {
            // Arrange
            var city = "Toronto";
            var mockResponse = new WeatherResponse
            {
                Coord = new Coord { Lon = 7.367f, Lat = 45.133f },
                Weather = new List<Weather>
                {
                    new Weather
                    {
                        Id = 501,
                        Main = "Rain",
                        Description = "moderate rain",
                        Icon = "10d"
                    }
                },
                Base = "stations",
                Main = new Main
                {
                    Temp = 284.2f,
                    FeelsLike = 282.93f,
                    TempMin = 283.06f,
                    TempMax = 286.82f,
                    Pressure = 1021,
                    Humidity = 60,
                    SeaLevel = 1021,
                    GrndLevel = 910
                },
                Visibility = 10000,
                Wind = new Wind
                {
                    Speed = 4.09f,
                    Deg = 121,
                    Gust = 3.47f
                },
                Clouds = new Clouds { All = 83 },
                Rain = new Rain { OneHour = 2.73f },
                Sys = new Sys
                {
                    Type = 1,
                    Id = 6736,
                    Country = "IT",
                    Sunrise = 1726636384,
                    Sunset = 1726680975
                },
                Dt = 1726660758,
                Timezone = 7200,
                Id = 3165523,
                Name = "Province of Turin",
                Cod = 200
            };

            var jsonResponse = JsonSerializer.Serialize(mockResponse);
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse)
                });

            // Act
            var result = await _weatherService.GetWeatherAsync(city);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mockResponse.Coord.Lat, result.Coord?.Lat);
            Assert.Equal(mockResponse.Coord.Lon, result.Coord?.Lon);
            Assert.Equal(mockResponse.Main.Temp, result.Main?.Temp);
            Assert.Equal(mockResponse.Main.Humidity, result.Main?.Humidity);
            Assert.Equal(mockResponse.Weather?[0].Description, result.Weather?[0].Description);
            Assert.Equal(mockResponse.Name, result.Name);
        }

        [Fact]
        public async Task GetWeatherAsync_ReturnsNull_WhenApiResponseIsNotSuccess()
        {
            // Arrange
            var city = "Toronto";

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                });

            // Act
            var result = await _weatherService.GetWeatherAsync(city);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetWeatherAsync_ThrowsException_WhenDeserializationFails()
        {
            // Arrange
            var city = "Toronto";

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("Invalid JSON")
                });

            // Act & Assert
            await Assert.ThrowsAsync<JsonException>(() => _weatherService.GetWeatherAsync(city));
        }
    }
}
