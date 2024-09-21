namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Monthly;

using Daily;
using Domain;
using FluentAssertions;
using Moq;


public sealed class MonthlyRankingUseCaseTests : TestContext {

    [Fact] public async Task ShouldCallServiceStatus200() {
        List<RankingDto> result = [new(1, 1, "Ncode"), new(2, 2, "Ncode")];
        List<RankingOutPut> result2 = [new("Ncode", 1, 1), new("Ncode", 2, 2)];
        var mockService = new Mock<IRankingService>();
        mockService.Setup(static service => service.GetRanking(It.IsAny<string>())).ReturnsAsync(result);
        Services.AddSingleton<IRankingService, RankingService>();
        var dailyRankingUseCase = new DailyRankingUseCase(mockService.Object);
        var data = await dailyRankingUseCase.Invoke(new RankingInput(DateTime.Now, FormatEnum.Json));
        mockService.Verify(expression: static v => v.GetRanking(It.IsAny<string>()), Times.Once());
        result2.Should().BeEquivalentTo(data, options => options.RespectingRuntimeTypes());
    }
}
