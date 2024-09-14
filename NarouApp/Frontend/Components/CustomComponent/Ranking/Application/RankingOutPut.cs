namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

using Domain;


public class RankingOutPut(string ncode, int pt, int rank) {
    public int rank { get; } = rank;
    public int Pt { get; } = pt;
    public string Ncode { get; } = ncode;

    internal static List<RankingOutPut> Convert(List<RankingDto> rankingDto) {
        return rankingDto.Select(static v => new RankingOutPut(v.Ncode, v.Pt, v.rank)).ToList();
    }
}
