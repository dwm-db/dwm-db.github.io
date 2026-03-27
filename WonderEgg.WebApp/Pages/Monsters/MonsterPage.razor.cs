using Microsoft.AspNetCore.Components;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Monsters
{
    public partial class MonsterPage
    {
        [Parameter]
        public required string MonsterName { get; set; }

        private bool dataLoaded => (monster is not null && breeds is not null);

        private Monster? monster;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            MonsterName = Uri.UnescapeDataString(MonsterName);

            monster = await DataService.GetMonsterByNameAsync(MonsterName);
            breeds = (await DataService.GetBreedsByMonsterAsync(MonsterName)) ?? [];

            if (!dataLoaded)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}
