namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Weekly;

using Domain;
using FluentAssertions;
using Moq;


public sealed class QuarterlyRankingUseCaseTests : TestContext {

    [Fact] public async Task ShouldCallServiceStatus200() {
        List<RankingDto> result =
        [
            new(2000,
            5000,
            7000,
            9000,
            1,
            "N8692BO",
            "title",
            1,
            "Writer",
            "Story",
            "KeyWord"),
            new(2000,
            5000,
            7000,
            9000,
            2,
            "N8692BO",
            "title",
            2,
            "Writer",
            "Story",
            "KeyWord")
        ];
        List<RankingOutPut> result2 =
        [
            new(2000,
            5000,
            7000,
            9000,
            1,
            "N8692BO",
            "title",
            1,
            "Writer",
            "Story",
            "KeyWord"),
            new(2000,
            5000,
            7000,
            9000,
            2,
            "N8692BO",
            "title",
            2,
            "Writer",
            "Story",
            "KeyWord")
        ];
        var mockService = new Mock<IRankingService>();
        mockService.Setup(static service => service.GetRanking(It.IsAny<string>()))
            .ReturnsAsync(result);
        Services.AddSingleton<IRankingService, RankingService>();
        var dailyRankingUseCase = new WeeklyRankingUseCase(mockService.Object);
        var data =
            await dailyRankingUseCase.Invoke(new RankingInput(DateTime.Now, FormatEnum.Json));
        mockService.Verify(expression: static v => v.GetRanking(It.IsAny<string>()), Times.Once());
        result2.Should().BeEquivalentTo(data);
    }
}
