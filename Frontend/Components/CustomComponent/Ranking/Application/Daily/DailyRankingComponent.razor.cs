namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Daily;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;


public sealed partial class DailyRankingComponent : ComponentBase {

    List<RankingOutPut> _result = [];
    [Inject(Key = nameof(DailyRankingUseCase))] BaseUseCase<RankingInput, List<RankingOutPut>> RankingUseCase { get; set; } = null!;

    protected override async Task OnInitializedAsync() {
        Console.WriteLine("call");
        _result = await RankingUseCase.Invoke(new RankingInput(DateTime.Now, FormatEnum.Json));
    }
}
