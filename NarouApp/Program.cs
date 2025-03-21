using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using NarouApp.Frontend.Components;
using NarouApp.Frontend.Components.CustomComponent.Ranking.Application;
using NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Daily;
using NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Monthly;
using NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Quarterly;
using NarouApp.Frontend.Components.CustomComponent.Ranking.Application.Weekly;
using NarouApp.Frontend.Components.CustomComponent.Ranking.Domain;
using NarouApp.Frontend.Components.CustomComponent.Ranking.Infrastructure;
using NarouApp.Frontend.Components.CustomComponent.Util;
using DateTime=NarouApp.Frontend.Components.CustomComponent.Util.DateTime;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services
    .AddBlazorise(static options => { options.Immediate = true; })
    .AddBulmaProviders()
    .AddSingleton<IRankingService, RankingService>()
    .AddSingleton<IRankingRepository, RankingRepositoryImpl>()
    .AddSingleton<IGetItemFromNcodeClient, GetItemFromNcodeClient>()
    .AddSingleton<IDateTime, DateTime>()
    .AddKeyedSingleton<IBaseUseCase<RankingInput, List<RankingOutPut>>, DailyRankingUseCase>(
    nameof(DailyRankingUseCase))
    .AddKeyedSingleton<IBaseUseCase<RankingInput, List<RankingOutPut>>, WeeklyRankingUseCase>(
    nameof(WeeklyRankingUseCase))
    .AddKeyedSingleton<IBaseUseCase<RankingInput, List<RankingOutPut>>, MonthlyRankingUseCase>(
    nameof(MonthlyRankingUseCase))
    .AddKeyedSingleton<IBaseUseCase<RankingInput, List<RankingOutPut>>, QuarterlyRankingUseCase>(
    nameof(QuarterlyRankingUseCase))
    .AddBlazoredLocalStorage()
    .AddFontAwesomeIcons();
builder.Services.AddHttpClient<IRankingRepository, RankingRepositoryImpl>(client =>
    client.DefaultRequestHeaders.Add("User-Agent",
    "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36"));
builder.Services.AddHttpClient<IGetItemFromNcodeClient, GetItemFromNcodeClient>(client =>
    client.DefaultRequestHeaders.Add("User-Agent",
    "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
