namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

public sealed class RankingService(IRankingRepository rankingRepository) : IRankingService {
    public async Task<List<RankingDto>> GetRanking(string url) {
        var result = await rankingRepository.GetRanking(url);
        return result;
    }
}
