namespace NarouBackend.Controllers;

using Bunit;
using Xunit;


public class WeatherForecastControllerTests : BunitContext {
    [Fact] public void WeatherForecastControllerTest() {
        var result = new WeatherForecastController().Get();
        Assert.Equal("", result);
    }
}
