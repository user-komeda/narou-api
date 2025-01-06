namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

using Domain;
using FluentAssertions;


public sealed class RankingOutPutTests {
    [Fact] public void ShouldConvertRankingDtoToRankingOutPut() {
        List<RankingDto> data =
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
        List<RankingOutPut> data2 =
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
        RankingOutPut.Convert(data).Should().BeEquivalentTo(data2);
    }
}
