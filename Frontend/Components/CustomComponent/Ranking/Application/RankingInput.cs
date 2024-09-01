namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

public sealed class RankingInput(DateTime dateTime, FormatEnum outFormat) {
    const string Url = "https://api.syosetu.com/rank/rankget/";


    internal string ConvertDailyQuery() => $"{Url}?rtype={dateTime:yyyyMMdd}-d&out={outFormat.ToString().ToLower()}";
    internal string ConvertWeeklyQuery() => $"{Url}?rtype={dateTime:yyyyMMdd}-w&out={outFormat.ToString().ToLower()}";
}
