namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using System.Text.Json.Serialization;
using Domain;


public class RankingEntity {
    [JsonPropertyName("pt")] public int Pt { get; set; }
    [JsonPropertyName("rank")] public int Rank { get; set; }
    [JsonPropertyName("ncode")] public string Ncode { get; set; }

    public static List<RankingDto> Convert(List<RankingEntity> rankingEntities) {
        return rankingEntities.Select(static v => new RankingDto(v.Pt, v.Rank, v.Ncode)).ToList();
    }
}
