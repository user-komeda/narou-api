namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

public interface IRankingService {
    Task<List<RankingDto>> GetDaialyRanking(string url);
}
