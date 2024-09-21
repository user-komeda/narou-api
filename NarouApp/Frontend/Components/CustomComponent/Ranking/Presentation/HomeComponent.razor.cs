using Microsoft.AspNetCore.Components;


namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Presentation;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;


public sealed partial class HomeComponent : ComponentBase {
    [Inject] private ProtectedLocalStorage LocalStorage { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender) {
        await base.OnAfterRenderAsync(firstRender);
        var uuid = await LocalStorage.GetAsync<string>("uuid");
        if (uuid.Value == null){
            await LocalStorage.SetAsync("uuid", Guid.NewGuid().ToString());
        }
    }
}
