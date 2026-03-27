using Microsoft.AspNetCore.Components.Routing;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Skills;

public partial class SkillListPage : IDisposable
{
    private Tabs currentTab = Tabs.ALL;
    private Skill[]? skills;

    protected override async Task OnInitializedAsync()
    {
        // Subscribe to the event
        NavigationManager.LocationChanged += LocationChanged;

        skills = await DataService.GetSkillsAsync();
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
            _ when (NavigationManager.Uri.EndsWith("/skill/type") || location.EndsWith("/skill/type")) => Tabs.TYPE,
            _ when (NavigationManager.Uri.EndsWith("/skill/category") || location.EndsWith("/skill/category")) => Tabs.CATEGORY,
            _ when (NavigationManager.Uri.EndsWith("/skill/attribute") || location.EndsWith("/skill/attribute")) => Tabs.ATTRIBUTE,
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
        TYPE,
        CATEGORY,
        ATTRIBUTE
    }
}
