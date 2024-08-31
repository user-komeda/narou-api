namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

public sealed class RankingService(IRankingRepository rankingRepository) : IRankingService {
    public async Task<List<RankingDto>> GetDaialyRanking(string url) {
        Console.WriteLine(url);
        var result = await rankingRepository.GetDaialyRanking(url);
        result.ForEach(static v => Console.WriteLine(v.Ncode, v.Pt, v.rank));
        return result;
    }
}
