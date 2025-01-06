namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

public interface IRankingService {
    Task<List<RankingDto>> GetRanking(string url);
}
