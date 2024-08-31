namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

public interface IRankingRepository {
    Task<List<RankingDto>> GetDaialyRanking(string url);
}
