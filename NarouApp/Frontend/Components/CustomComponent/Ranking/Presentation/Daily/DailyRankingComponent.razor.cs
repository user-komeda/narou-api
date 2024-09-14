namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Presentation.Daily;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Application.Daily;
using Microsoft.AspNetCore.Components;
using Util;


public sealed partial class DailyRankingComponent : ComponentBase {

    List<RankingOutPut> _result = [];
    [Inject(Key = nameof(DailyRankingUseCase))] IBaseUseCase<RankingInput, List<RankingOutPut>> RankingUseCase { get; set; } = null!;

    protected override async Task OnInitializedAsync() {
        _result = await RankingUseCase.Invoke(new RankingInput(DateTime.Now, FormatEnum.Json));
    }
}
