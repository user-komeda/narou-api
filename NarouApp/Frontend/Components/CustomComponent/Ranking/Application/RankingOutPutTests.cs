namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

using Domain;
using FluentAssertions;


public sealed class RankingOutPutTests {
    [Fact] public void ShouldConvertRankingDtoToRankingOutPut() {
        List<RankingDto> data = [new(1, 1, "Ncode"), new(2, 2, "Ncode")];
        List<RankingOutPut> data2 = [new("Ncode", 1, 1), new("Ncode", 2, 2)];
        RankingOutPut.Convert(data).Should().BeEquivalentTo(data2);
    }
}
