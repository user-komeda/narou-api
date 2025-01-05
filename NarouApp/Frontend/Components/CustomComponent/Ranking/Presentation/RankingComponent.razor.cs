using Microsoft.AspNetCore.Components;


namespace NarouApp.Frontend.Components.CustomComponent.Ranking.Presentation;

using Application;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using JsonSerializer=System.Text.Json.JsonSerializer;


public sealed partial class RankingComponent : ComponentBase {

    [Parameter] public List<RankingOutPut> ResultData { get; set; } = [];
    [Inject] public ILocalStorageService LocalStorage { get; set; } = null!;
    private async Task Click(string ncode) {
        Console.WriteLine(ncode);
        var uuid = await LocalStorage.GetItemAsync<string>("uuid");
        if (uuid == null){
            throw new Exception();
        }
        var ncodeJson = await LocalStorage.GetItemAsync<string>(uuid);
        Console.WriteLine(ncodeJson);
        if (ncodeJson == null){
            Console.WriteLine("aaa");
            await LocalStorage.SetItemAsync(uuid, JsonConvert.SerializeObject(new List<KeyValuePair<string, string>> { new("ncode", ncode) }));
            return;
        }
        var deserializeNcodeList = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(ncodeJson) ?? [];
        deserializeNcodeList.Add(new KeyValuePair<string, string>("ncode", ncode));
        await LocalStorage.SetItemAsync(uuid, JsonSerializer.Serialize(deserializeNcodeList));
    }
}
