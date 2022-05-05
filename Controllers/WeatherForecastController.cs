using Interceptor.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interceptor.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;


    private readonly ILogger<WeatherForecastController> _logger;
    public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }



    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _weatherService.GetWeatherForecast();
    }
}
