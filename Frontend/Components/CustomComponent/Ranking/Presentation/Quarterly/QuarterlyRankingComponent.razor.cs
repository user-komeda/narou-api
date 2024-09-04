using Microsoft.AspNetCore.Components;


namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Presentation.Quarterly;

using Application;
using Application.Quarterly;
using Util;


public sealed partial class QuarterlyRankingComponent : ComponentBase {
    List<RankingOutPut> _result = [];
    [Inject(Key = nameof(QuarterlyRankingUseCase))] IBaseUseCase<RankingInput, List<RankingOutPut>> RankingUseCase { get; set; } = null!;

    protected override async Task OnInitializedAsync() {
        _result = await RankingUseCase.Invoke(new RankingInput(GetFirstDay(DateTime.Now), FormatEnum.Json));
    }

    static DateTime GetFirstDay(DateTime dateTime) => new(dateTime.Year, dateTime.Month, 1);
}
