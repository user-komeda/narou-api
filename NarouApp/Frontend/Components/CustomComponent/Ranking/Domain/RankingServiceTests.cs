namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

using Infrastructure;
using Moq;


public sealed class RankingServiceTests : TestContext {
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
        var mockRepository = new Mock<IRankingRepository>();
        mockRepository.Setup(static repository => repository.GetRanking(It.IsAny<string>()))
            .ReturnsAsync(result);
        Services.AddSingleton<IRankingRepository, RankingRepositoryImpl>();
        var rankingService = new RankingService(mockRepository.Object);
        await rankingService.GetRanking(It.IsAny<string>());
        mockRepository.Verify(expression: static v => v.GetRanking(It.IsAny<string>()),
        Times.Once());
    }
}
