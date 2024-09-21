namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using Domain;
using FluentAssertions;


public class RankingEntityTests : TestContext {
    [Fact] public void ShouldConvertRankingEntityToRankingDto() {
        List<RankingEntity> data =
        [
            new RankingEntity { Rank = 1, Ncode = "Ncode", Pt = 1 }, new RankingEntity { Rank = 2, Ncode = "Ncode", Pt = 2 }
        ];
        List<RankingDto> data2 = [new(rank: 1, ncode: "Ncode", pt: 1), new(rank: 2, ncode: "Ncode", pt: 2)];

        RankingEntity.Convert(data).Should().BeEquivalentTo(data2);
    }
}
