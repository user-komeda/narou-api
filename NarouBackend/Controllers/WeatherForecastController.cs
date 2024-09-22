using Microsoft.AspNetCore.Mvc;


namespace NarouBackend.Controllers;

using Microsoft.AspNetCore.Authorization;


[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase {


    readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger) {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")] [Authorize] public void Get() {
        _logger.Log(LogLevel.Critical, "controller");
    }
}
