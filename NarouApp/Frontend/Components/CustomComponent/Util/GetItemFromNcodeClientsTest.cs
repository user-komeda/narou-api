namespace NarouApp.Frontend.Components.CustomComponent.Util;

using System.Net;
using System.Web;
using FluentAssertions;
using Ranking.Infrastructure;
using RichardSzalay.MockHttp;


public class GetItemFromNcodeClientsTest : TestContext {
    [Fact] public async Task ShouldGetItemFromNcodeClientsStatusOk() {

        List<RankingEntity> data =
        [
            new RankingEntity { Rank = 1, Ncode = "N8692BO" },
            new RankingEntity { Rank = 2, Ncode = "N8692B1" }
        ];
        List<RankingEntity> resultEntity =
        [
            new RankingEntity
            {
                DailyPoint = 2000, WeeklyPoint = 5000, MonthlyPoint = 7000, QuarterlyPoint = 9000,
                Rank = 1, Ncode = "N8692BO", Title = "title", UserId = 1, Writer = "writer",
                Story = "story", KeyWord = "keyWord"
            },
            new RankingEntity
            {
                DailyPoint = 2000, WeeklyPoint = 5000, MonthlyPoint = 7000, QuarterlyPoint = 9000,
                Rank = 2, Ncode = "N8692B1", Title = "title", UserId = 2, Writer = "writer",
                Story = "story", KeyWord = "keyWord"
            }
        ];

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect(
            "https://api.syosetu.com/novelapi/api/?ncode=N8692BO-N8692B1&out=json&lim=400&order=dailypoint")
            .Respond("application/json",
            "[" +
            "{\"daily_point\":2000,\"weekly_point\":5000,\"monthly_point\":7000,\"quarter_point\":9000,\"rank\":1,\"ncode\":\"N8692BO\"," +
            "\"title\":\"title\",\"userid\":1,\"writer\":\"writer\",\"story\":\"story\",\"keyword\":\"keyWord\"}," +
            "{\"daily_point\":2000,\"weekly_point\":5000,\"monthly_point\":7000,\"quarter_point\":9000,\"rank\":2,\"ncode\":\"N8692B1\"," +
            "\"title\":\"title\",\"userid\":2,\"writer\":\"writer\",\"story\":\"story\",\"keyword\":\"keyWord\"}" +
            "]");
        var client = mockHttp.ToHttpClient();

        var getItemFromNcodeClient = new GetItemFromNcodeClient(client);
        var result = await getItemFromNcodeClient.Invoke(data,
        HttpUtility.ParseQueryString(
        $"https://api.syosetu.com/rank/rankget/?rtype={System.DateTime.Now:yyyyMMdd}-d&out=json&lim=400&order=dailypoint"
            .Split("?")[1]));
        result.Should().BeEquivalentTo(resultEntity);
    }

    [Fact] public async Task ShouldGetItemFromNcodeClientsStatusError() {

        List<RankingEntity> data =
        [
            new RankingEntity { Rank = 1, Ncode = "N8692BO" },
            new RankingEntity { Rank = 2, Ncode = "N8692B1" }
        ];

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect(
            "https://api.syosetu.com/novelapi/api/?ncode=N8692BO-N8692B1&out=json&lim=400&order=dailypoint")
            .Respond(HttpStatusCode.InternalServerError);
        var client = mockHttp.ToHttpClient();

        var getItemFromNcodeClient = new GetItemFromNcodeClient(client);
        var result = await getItemFromNcodeClient.Invoke(data,
        HttpUtility.ParseQueryString(
        $"https://api.syosetu.com/rank/rankget/?rtype={System.DateTime.Now:yyyyMMdd}-d&out=json&lim=400&order=dailypoint"
            .Split("?")[1]));
        result.Should().BeEquivalentTo(new List<RankingEntity>());
    }
    [Fact] public async Task ShouldGetItemFromNcodeClientsThrowError() {

        List<RankingEntity> data =
        [
            new RankingEntity { Rank = 1, Ncode = "N8692BO" },
            new RankingEntity { Rank = 2, Ncode = "N8692B1" }
        ];

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect(
            "https://api.syosetu.com/novelapi/api/?ncode=N8692BO-N8692B1&out=json&lim=400&order=dailypoint")
            .Respond(HttpStatusCode.InternalServerError);
        var client = mockHttp.ToHttpClient();

        var getItemFromNcodeClient = new GetItemFromNcodeClient(client);
        await Assert.ThrowsAsync<Exception>(async () => await getItemFromNcodeClient.Invoke(data,
        HttpUtility.ParseQueryString(
        "https://api.syosetu.com/rank/rankget/?"
            .Split("?")[1])));
    }
}
