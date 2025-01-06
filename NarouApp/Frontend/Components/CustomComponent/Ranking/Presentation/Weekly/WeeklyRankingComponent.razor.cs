using Microsoft.AspNetCore.Components;


namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Presentation.Weekly;

using Application;
using Application.Weekly;
using Util;


public sealed partial class WeeklyRankingComponent : ComponentBase {
    List<RankingOutPut> _result = [];

    [Inject(Key = nameof(WeeklyRankingUseCase))]
    IBaseUseCase<RankingInput, List<RankingOutPut>> RankingUseCase { get; set; } = null!;

    [Inject] IDateTime DateTime { get; set; } = null!;


    protected override async Task OnInitializedAsync() {
        _result = await RankingUseCase.Invoke(new RankingInput(
        GetTuesday(DateTime.GetDateTimeNow()),
        FormatEnum.Json));
    }

    static System.DateTime GetTuesday(System.DateTime dateTime) {
        var week = dateTime.DayOfWeek;
        return week == DayOfWeek.Tuesday ? dateTime : dateTime.AddDays(-(int)week - 5);
    }
}
