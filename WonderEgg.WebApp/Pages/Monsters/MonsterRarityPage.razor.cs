using Microsoft.AspNetCore.Components;
using WonderEgg.Core;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Monsters
{
    public partial class MonsterRarityPage
    {
        [Parameter]
        public required string RarityName { get; set; }

        private bool dataLoaded => (monsters is not null && breeds is not null);

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            RarityName = Uri.UnescapeDataString(RarityName);
            if (Enum.IsDefined(typeof(MonsterRarity), RarityName) || Enum.IsDefined(typeof(MonsterRarity), int.TryParse(RarityName, out var value) ? value : string.Empty))
            {
                var _rarity = Enum.Parse<MonsterRarity>(RarityName);
                RarityName = _rarity.ToJsonString();
                monsters = await DataService.GetMonstersByRarityAsync(_rarity);
                breeds = (await DataService.GetBreedsByRarityAsync(_rarity)) ?? [];
            }

            if (!dataLoaded)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}
