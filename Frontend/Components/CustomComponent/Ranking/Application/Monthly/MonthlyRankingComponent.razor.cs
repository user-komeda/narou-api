using Microsoft.AspNetCore.Components;


namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Monthly;

public sealed partial class MonthlyRankingComponent : ComponentBase {
    List<RankingOutPut> _result = [];
    [Inject(Key = nameof(MonthlyRankingUseCase))] BaseUseCase<RankingInput, List<RankingOutPut>> RankingUseCase { get; set; } = null!;

    protected override async Task OnInitializedAsync() {
        _result = await RankingUseCase.Invoke(new RankingInput(GetFirstDay(DateTime.Now), FormatEnum.Json));
    }

    static DateTime GetFirstDay(DateTime dateTime) => new(dateTime.Year, dateTime.Month, 1);
}
