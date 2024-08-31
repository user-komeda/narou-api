namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

using Domain;


public sealed class RankingOutPut(string ncode, int pt, int rank) {
    internal int rank { get; } = rank;
    internal int Pt { get; } = pt;
    internal string Ncode { get; } = ncode;

    internal static List<RankingOutPut> Convert(List<RankingDto> rankingDto) {
        return rankingDto.Select(static v => new RankingOutPut(v.Ncode, v.Pt, v.rank)).ToList();
    }
}
