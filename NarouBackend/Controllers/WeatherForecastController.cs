using Microsoft.AspNetCore.Mvc;


namespace NarouBackend.Controllers;

using Microsoft.AspNetCore.Authorization;


[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase {
    [HttpGet(Name = "GetWeatherForecast")] [Authorize] public string Get() => "";
}
