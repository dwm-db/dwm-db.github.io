using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DWMLibrary.WebApp.Pages.Monsters;

public partial class MonsterListPage : IDisposable
{
    private bool dataLoaded => (monsters is not null && monsters.Length > 0);

    private Tabs currentTab = Tabs.ALL;
    private Monster[]? monsters;

    protected override async Task OnInitializedAsync()
    {
        // Subscribe to the event
        NavigationManager.LocationChanged += LocationChanged;

        monsters = await DataService.GetMonstersAsync();
    }

    protected override void OnParametersSet()
    {
        SwitchCurrentTab();
    }

    void LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        string navigationMethod = e.IsNavigationIntercepted ? "HTML" : "code";
        string location = e.Location;
        SwitchCurrentTab(location);
        StateHasChanged();
    }

    void SwitchCurrentTab(string? location = null)
    {
        location ??= string.Empty;

        currentTab = currentTab switch
        {
            _ when (NavigationManager.Uri.EndsWith("/monster/family") || location.EndsWith("/monster/family")) => Tabs.FAMILY,
            _ when (NavigationManager.Uri.EndsWith("/monster/location") || location.EndsWith("/monster/location")) => Tabs.LOCATION,
            _ when (NavigationManager.Uri.EndsWith("/monster/size") || location.EndsWith("/monster/size")) => Tabs.SIZE,
            _ when (NavigationManager.Uri.EndsWith("/monster/rarity") || location.EndsWith("/monster/rarity")) => Tabs.RARITY,
            _ => Tabs.ALL

        };
    }

    void IDisposable.Dispose()
    {
        // Unsubscribe from the event when our component is disposed
        NavigationManager.LocationChanged -= LocationChanged;
    }

    private string IsShowActive(Tabs tab)
    {
        return (tab == currentTab) ? "show active" : string.Empty;
    }

    private enum Tabs
    {
        ALL,
        FAMILY,
        LOCATION,
        SIZE,
        RARITY
    }
}
