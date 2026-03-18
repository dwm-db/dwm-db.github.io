using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Monsters
{
    public partial class MonsterPage
    {
        [Parameter]
        public required string MonsterName { get; set; }

        private bool dataLoaded => (monster is not null && breeds is not null);
        private bool notFound = false;

        private Monster? monster;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            MonsterName = Uri.UnescapeDataString(MonsterName);

            monster = await DataService.GetMonsterByNameAsync(MonsterName);
            breeds = (await DataService.GetBreedsByMonsterAsync(MonsterName)) ?? [];

            notFound = (monster is null);
        }
    }
}
