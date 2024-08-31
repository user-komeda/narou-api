namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

public class RankingInput(DateTime dateTime, FormatEnum outFormat) {
    const string Url = "https://api.syosetu.com/rank/rankget/";


    public string ConvertQuery() => $"{Url}?rtype={dateTime:yyyyMMdd}-d&out={outFormat.ToString().ToLower()}";
}
