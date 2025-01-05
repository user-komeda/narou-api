namespace NarouBackend.Controllers;

using Bunit;
using Xunit;


public class WeatherForecastControllerTests : TestContext {
    [Fact] public void weatherForecastControllerTest() {
        var result = new WeatherForecastController().Get();
        Assert.Equal("", result);
    }
}
