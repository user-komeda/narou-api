namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using System.Net;
using Domain;
using FluentAssertions;
using RichardSzalay.MockHttp;


public sealed class RankingRepositoryImplTests : TestContext {
    [Fact] public async Task ShouldHttpStatusOk() {
        List<RankingDto> result = [new RankingDto(4158, 1, "N8692BO"), new RankingDto(3166, 2, "N0156BP")];
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("https://api.syosetu.com/rank/rankget/")
            .Respond("application/json", "[{\"ncode\":\"N8692BO\",\"pt\":4158,\"rank\":1},{\"ncode\":\"N0156BP\",\"pt\":3166,\"rank\":2}]");
        var client = mockHttp.ToHttpClient();

        var rankingRepositoryImpl = new RankingRepositoryImpl(client);
        var data = await rankingRepositoryImpl.GetRanking("https://api.syosetu.com/rank/rankget/");

        data.Should().BeEquivalentTo(result);
    }

    [Fact] public async Task ShouldHttpStatusError() {
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("https://api.syosetu.com/rank/rankget/")
            .Respond(HttpStatusCode.InternalServerError);
        var client = mockHttp.ToHttpClient();

        var rankingRepositoryImpl = new RankingRepositoryImpl(client);
        var data = await rankingRepositoryImpl.GetRanking("https://api.syosetu.com/rank/rankget/");

        data.Should().BeEquivalentTo(new List<RankingDto>());
    }
}
