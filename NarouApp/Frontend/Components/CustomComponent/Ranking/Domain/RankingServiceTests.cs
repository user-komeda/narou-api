namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

using Infrastructure;
using Moq;


public sealed class RankingServiceTests : TestContext {
    [Fact] public async Task ShouldCallServiceStatus200() {
        List<RankingDto> result = [new RankingDto(1, 1, "Ncode"), new RankingDto(2, 2, "Ncode")];
        var mockRepository = new Mock<IRankingRepository>();
        mockRepository.Setup(static repository => repository.GetRanking(It.IsAny<string>())).ReturnsAsync(result);
        Services.AddSingleton<IRankingRepository, RankingRepositoryImpl>();
        var rankingService = new RankingService(mockRepository.Object);
        await rankingService.GetRanking(It.IsAny<string>());
        mockRepository.Verify(expression: static v => v.GetRanking(It.IsAny<string>()), Times.Once());
    }
}
