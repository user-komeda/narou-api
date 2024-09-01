namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

public sealed class RankingService(IRankingRepository rankingRepository) : IRankingService {
    public async Task<List<RankingDto>> GetDaialyRanking(string url) {
        Console.WriteLine(url);
        var result = await rankingRepository.GetDaialyRanking(url);
        return result;
    }
}
