using Microsoft.AspNetCore.Components;


namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Presentation.Monthly;

using Application;
using Application.Monthly;
using Util;
using DateTime=DateTime;


public sealed partial class MonthlyRankingComponent : ComponentBase {
    List<RankingOutPut> _result = [];

    [Inject(Key = nameof(MonthlyRankingUseCase))]
    IBaseUseCase<RankingInput, List<RankingOutPut>> RankingUseCase { get; set; } = null!;

    [Inject] IDateTime DateTime { get; set; } = null!;


    protected override async Task OnInitializedAsync() {
        _result = await RankingUseCase.Invoke(new RankingInput(
        GetFirstDay(DateTime.GetDateTimeNow()),
        FormatEnum.Json));
    }

    static DateTime GetFirstDay(DateTime dateTime) => new(dateTime.Year, dateTime.Month, 1);
}
