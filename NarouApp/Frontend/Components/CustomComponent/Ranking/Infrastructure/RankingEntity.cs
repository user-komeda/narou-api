namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using System.Text.Json.Serialization;
using Domain;


public class RankingEntity {
    [JsonPropertyName("daily_point")] public int DailyPoint { get; set; }
    [JsonPropertyName("weekly_point")] public int WeeklyPoint { get; set; }
    [JsonPropertyName("monthly_point")] public int MonthlyPoint { get; set; }
    [JsonPropertyName("quarter_point")] public int QuarterlyPoint { get; set; }
    [JsonPropertyName("rank")] public int Rank { get; set; }
    [JsonPropertyName("ncode")] public string Ncode { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("userid")] public int UserId { get; set; }
    [JsonPropertyName("writer")] public string Writer { get; set; }
    [JsonPropertyName("story")] public string Story { get; set; }
    [JsonPropertyName("keyword")] public string KeyWord { get; set; }

    public static List<RankingDto> Convert(List<RankingEntity> rankingEntities) {
        return rankingEntities.Skip(1).Select(static v => new RankingDto(v.DailyPoint,
        v.WeeklyPoint,
        v.MonthlyPoint,
        v.QuarterlyPoint,
        v.Rank,
        v.Ncode,
        v.Title,
        v.UserId,
        v.Writer,
        v.Story,
        v.KeyWord)).ToList();
    }
}
