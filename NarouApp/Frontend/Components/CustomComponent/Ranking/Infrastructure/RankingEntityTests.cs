namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using Domain;
using FluentAssertions;


public sealed class RankingEntityTests : TestContext {
    [Fact] public void ShouldConvertRankingEntityToRankingDto() {
        List<RankingEntity> data =
        [
            new RankingEntity
            {
                DailyPoint = 0, WeeklyPoint = 0, MonthlyPoint = 0, QuarterlyPoint = 0,
                Rank = 0, Ncode = "", Title = "", UserId = 1, Writer = "",
                Story = "", KeyWord = ""
            },
            new RankingEntity
            {
                DailyPoint = 2000, WeeklyPoint = 5000, MonthlyPoint = 7000, QuarterlyPoint = 9000,
                Rank = 1, Ncode = "N8692BO", Title = "title", UserId = 1, Writer = "Writer",
                Story = "Story", KeyWord = "KeyWord"
            },
            new RankingEntity
            {
                DailyPoint = 2000, WeeklyPoint = 5000, MonthlyPoint = 7000, QuarterlyPoint = 9000,
                Rank = 2, Ncode = "N8692BO", Title = "title", UserId = 2, Writer = "Writer",
                Story = "Story", KeyWord = "KeyWord"
            }
        ];
        List<RankingDto> data2 =
        [
            new(2000,
            5000,
            7000,
            9000,
            1,
            "N8692BO",
            "title",
            1,
            "Writer",
            "Story",
            "KeyWord"),
            new(2000,
            5000,
            7000,
            9000,
            2,
            "N8692BO",
            "title",
            2,
            "Writer",
            "Story",
            "KeyWord")
        ];

        RankingEntity.Convert(data).Should().BeEquivalentTo(data2);
    }
}
