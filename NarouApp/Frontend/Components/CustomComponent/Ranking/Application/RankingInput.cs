namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

public sealed class RankingInput(DateTime dateTime, FormatEnum outFormat) {
    const string Url = "https://api.syosetu.com/rank/rankget/";
    public string ConvertDailyQuery() => $"{Url}?rtype={dateTime:yyyyMMdd}-d&out={outFormat.ToString().ToLower()}";
    public string ConvertWeeklyQuery() => $"{Url}?rtype={dateTime:yyyyMMdd}-w&out={outFormat.ToString().ToLower()}";
    public string ConvertMonthlyQuery() => $"{Url}?rtype={dateTime:yyyyMMdd}-m&out={outFormat.ToString().ToLower()}";
    public string ConvertQuarterlyQuery() => $"{Url}?rtype={dateTime:yyyyMMdd}-q&out={outFormat.ToString().ToLower()}";

}
