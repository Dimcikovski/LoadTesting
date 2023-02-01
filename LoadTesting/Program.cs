using LoadTesting.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRandomizer, Randomizer>();
builder.Services.AddSingleton<ISortingService, SortingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/load/v1", async () =>
    {
        var client = new HttpClient();
        var result = await client.GetAsync("https://catfact.ninja/fact");
        var some = await result.Content.ReadAsStringAsync();
        return some;
    })
    .WithName("LoadTestingV1");

app.MapGet("/load/v2", (ISortingService sortingService, HttpContext _) =>
    {
        sortingService.SortArray(SortingAlgorithm.BubbleSort);
        return "Done";
    })
    .WithName("LoadTestingV2");

app.MapGet("/load/v3", (ISortingService sortingService, HttpContext _) =>
    {
        sortingService.SortArray(SortingAlgorithm.QuickSort);
        return "Done";
    })
    .WithName("LoadTestingV3");

app.MapGet("/stress/v1", (ISortingService sortingService, HttpContext _) =>
    {
        sortingService.SortArray(SortingAlgorithm.BubbleSort);
        return "Done";
    })
    .WithName("StressTestingV1");

app.MapGet("/stress/v2", (ISortingService sortingService, HttpContext _) =>
    {
        sortingService.SortArray(SortingAlgorithm.QuickSort);
        return "Done";
    })
    .WithName("StressTestingV2");

app.MapGet("/spike/v1", (ISortingService sortingService, HttpContext _) =>
    {
        sortingService.SortArray(SortingAlgorithm.BubbleSort);
        return "Done";
    })
    .WithName("SpikeTestingV1");

app.MapGet("/spike/v2", (ISortingService sortingService, HttpContext _) =>
    {
        sortingService.SortArray(SortingAlgorithm.QuickSort);
        return "Done";
    })
    .WithName("SpikeTestingV2");

app.MapGet("/soak/v1", (ISortingService sortingService, HttpContext _) =>
    {
        sortingService.SortArray(SortingAlgorithm.BubbleSort);
        return "Done";
    })
    .WithName("SoakTestingV1");

app.MapGet("/soak/v2", (ISortingService sortingService, HttpContext _) =>
    {
        sortingService.SortArray(SortingAlgorithm.QuickSort);
        return "Done";
    })
    .WithName("SoakTestingV2");

app.Run();