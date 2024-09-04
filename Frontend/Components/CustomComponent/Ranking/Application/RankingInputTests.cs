namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

using FluentAssertions;


public sealed class RankingInputTests {
    const string Url = "https://api.syosetu.com/rank/rankget/";
    const FormatEnum OutFormat = FormatEnum.Json;
    readonly static DateTime ToDay = DateTime.Now;
    readonly static RankingInput RankingInput = new(ToDay, OutFormat);
    [Fact] public void ShouldConvertDailyQueryReturnToUrl() {
        RankingInput.ConvertDailyQuery().Should().Be($"{Url}?rtype={ToDay:yyyyMMdd}-d&out={OutFormat.ToString().ToLower()}");
        Assert.Equal(RankingInput.ConvertDailyQuery(), $"{Url}?rtype={ToDay:yyyyMMdd}-d&out={OutFormat.ToString().ToLower()}");
    }

    [Fact] public void ShouldConvertWeeklyQueryReturnToUrl() {

        Assert.Equal(RankingInput.ConvertWeeklyQuery(), $"{Url}?rtype={ToDay:yyyyMMdd}-w&out={OutFormat.ToString().ToLower()}");
    }

    [Fact] public void ShouldConvertMonthlyQueryReturnToUrl() {
        Assert.Equal(RankingInput.ConvertMonthlyQuery(), $"{Url}?rtype={ToDay:yyyyMMdd}-m&out={OutFormat.ToString().ToLower()}");
    }

    [Fact] public void ShouldConvertQuarterlyQueryReturnToUrl() {
        Assert.Equal(RankingInput.ConvertQuarterlyQuery(), $"{Url}?rtype={ToDay:yyyyMMdd}-q&out={OutFormat.ToString().ToLower()}");
    }
}
