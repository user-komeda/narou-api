using Microsoft.AspNetCore.Mvc;


namespace NarouBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase {


    readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger) {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")] public void Get() {
        _logger.Log(LogLevel.Critical, "controller");
    }
}
