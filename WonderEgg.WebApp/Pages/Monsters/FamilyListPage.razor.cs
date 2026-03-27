using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Monsters;

public partial class FamilyListPage
{
    private Monster[]? monsters;

    protected override async Task OnInitializedAsync()
    {
        monsters = await DataService.GetMonstersAsync();
    }
}