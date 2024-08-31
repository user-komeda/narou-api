namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;

public class RankingDto(int pt, int rank, string ncode) {
    internal int Pt { get; } = pt;
    internal int rank { get; } = rank;
    internal string Ncode { get; } = ncode;
}
