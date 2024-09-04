namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

public class RankingDto(int pt, int rank, string ncode) {
    public int Pt { get; } = pt;
    public int rank { get; } = rank;
    public string Ncode { get; } = ncode;
}
