using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Monsters;

public partial class LocationListPage
{
    private Monster[]? monsters;

    protected override async Task OnInitializedAsync()
    {
        monsters = await DataService.GetMonstersAsync();
    }
}