namespace Interceptor.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetWeatherForecast();
    }
}