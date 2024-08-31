namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Application;

using Microsoft.AspNetCore.Components;


public sealed partial class RankingComponent : ComponentBase {

    List<RankingOutPut> _result = [];
    [Inject] BaseUseCase<RankingInput, List<RankingOutPut>> RankingUseCase { get; set; } = null!;

    protected override async Task OnInitializedAsync() {
        Console.WriteLine("call");
        _result = await RankingUseCase.Invoke(new RankingInput(DateTime.Now, FormatEnum.Json));
    }
}
