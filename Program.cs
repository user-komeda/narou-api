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


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services
    .AddBlazorise(static options => { options.Immediate = true; })
    .AddBulmaProviders()
    .AddSingleton<IRankingService, RankingService>()
    .AddSingleton<IRankingRepository, RankingRepository>()
    .AddKeyedSingleton<BaseUseCase<RankingInput, List<RankingOutPut>>, DailyRankingUseCase>(nameof(DailyRankingUseCase))
    .AddKeyedSingleton<BaseUseCase<RankingInput, List<RankingOutPut>>, WeeklyRankingUseCase>(nameof(WeeklyRankingUseCase))
    .AddKeyedSingleton<BaseUseCase<RankingInput, List<RankingOutPut>>, MonthlyRankingUseCase>(nameof(MonthlyRankingUseCase))
    .AddKeyedSingleton<BaseUseCase<RankingInput, List<RankingOutPut>>, QuarterlyRankingUseCase>(nameof(QuarterlyRankingUseCase))
    .AddFontAwesomeIcons();
builder.Services.AddHttpClient<IRankingRepository, RankingRepository>(client => client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36"));

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
