var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.RootComponents.Add<HeaderView>("body > header");
builder.RootComponents.Add<MainView>("body > main");
builder.RootComponents.Add<FooterView>("body > footer");

builder.Services.AddSingleton<IDataService, DataService>(service =>
{
    var httpClient = new HttpClient()
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    };
    return new DataService(httpClient);
});

await builder.Build().RunAsync();
