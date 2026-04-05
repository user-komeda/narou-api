namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

using Domain;


public class RankingOutPut(
    int dailyPoint,
    int weeklyPoint,
    int monthlyPoint,
    int quarterlyPoint,
    string ncode,
    string title,
    string writer,
    string story,
    string keyWord) {
    public int DailyPoint { get; } = dailyPoint;
    public int WeeklyPoint { get; } = weeklyPoint;
    public int MonthlyPoint { get; } = monthlyPoint;
    public int QuarterlyPoint { get; } = quarterlyPoint;
    public string Ncode { get; } = ncode;
    public string Title { get; } = title;
    public string Writer { get; } = writer;
    public string Story { get; } = story;
    public string KeyWord { get; } = keyWord;

    internal static List<RankingOutPut> Convert(List<RankingDto> rankingDto) {
        return rankingDto.Select(static v => new RankingOutPut(v.DailyPoint,
        v.WeeklyPoint,
        v.MonthlyPoint,
        v.QuarterlyPoint,
        v.Ncode,
        v.Title,
        v.Writer,
        v.Story,
        v.KeyWord)).ToList();
    }
}
