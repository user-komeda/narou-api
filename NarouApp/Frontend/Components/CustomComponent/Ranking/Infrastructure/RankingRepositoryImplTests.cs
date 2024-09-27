namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;

using System.Collections.Specialized;
using System.Net;
using Domain;
using FluentAssertions;
using Moq;
using RichardSzalay.MockHttp;
using Util;
using DateTime=DateTime;


public sealed class RankingRepositoryImplTests : TestContext {
    [Fact] public async Task ShouldHttpStatusOk() {
        List<RankingDto> result =
        [
            new(2000,
            5000,
            7000,
            9000,
            1,
            "N8692BO",
            "title",
            1,
            "writer",
            "stroy",
            "keyWord"),
            new(2000,
            5000,
            7000,
            9000,
            2,
            "N8692B1",
            "title",
            2,
            "writer",
            "stroy",
            "keyWord")
        ];
        List<RankingEntity> resultEntity =
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
                Rank = 1, Ncode = "N8692BO", Title = "title", UserId = 1, Writer = "writer",
                Story = "stroy", KeyWord = "keyWord"
            },
            new RankingEntity
            {
                DailyPoint = 2000, WeeklyPoint = 5000, MonthlyPoint = 7000, QuarterlyPoint = 9000,
                Rank = 2, Ncode = "N8692B1", Title = "title", UserId = 2, Writer = "writer",
                Story = "stroy", KeyWord = "keyWord"
            }
        ];

        var mockGetItemFromNcodeClient = new Mock<IGetItemFromNcodeClient>();
        mockGetItemFromNcodeClient.Setup(static getItemFromNcodeClient =>
            getItemFromNcodeClient.Invoke(It.IsAny<List<RankingEntity>>(),
            It.IsAny<NameValueCollection>())).ReturnsAsync(resultEntity);
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect(
            $"https://api.syosetu.com/rank/rankget/?rtype={DateTime.Now:yyyyMMdd}-d&out=json&lim=400&order=dailypoint")
            .Respond("application/json",
            "[{\"ncode\":\"N8692BO\",\"pt\":4158,\"rank\":1},{\"ncode\":\"N0156BP\",\"pt\":3166,\"rank\":2}]");
        var client = mockHttp.ToHttpClient();

        var rankingRepositoryImpl =
            new RankingRepositoryImpl(client, mockGetItemFromNcodeClient.Object);
        var data =
            await rankingRepositoryImpl.GetRanking(
            $"https://api.syosetu.com/rank/rankget/?rtype={DateTime.Now:yyyyMMdd}-d&out=json&lim=400&order=dailypoint");

        data.Should().BeEquivalentTo(result);
    }

    [Fact] public async Task ShouldHttpStatusError() {
        var mockGetItemFromNcodeClient = new Mock<IGetItemFromNcodeClient>();
        mockGetItemFromNcodeClient.Setup(static getItemFromNcodeClient =>
            getItemFromNcodeClient.Invoke(It.IsAny<List<RankingEntity>>(),
            It.IsAny<NameValueCollection>())).ReturnsAsync([]);
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect(
            $"https://api.syosetu.com/rank/rankget/?rtype={DateTime.Now:yyyyMMdd}-d&out=json&lim=400&order=dailypoint")
            .Respond(HttpStatusCode.InternalServerError);
        var client = mockHttp.ToHttpClient();

        var rankingRepositoryImpl =
            new RankingRepositoryImpl(client, mockGetItemFromNcodeClient.Object);
        var data =
            await rankingRepositoryImpl.GetRanking(
            $"https://api.syosetu.com/rank/rankget/?rtype={DateTime.Now:yyyyMMdd}-d&out=json&lim=400&order=dailypoint");

        data.Should().BeEquivalentTo(new List<RankingDto>());
    }
}
