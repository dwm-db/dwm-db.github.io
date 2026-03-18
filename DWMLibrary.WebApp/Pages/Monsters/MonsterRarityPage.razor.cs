using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Monsters
{
    public partial class MonsterRarityPage
    {
        [Parameter]
        public required string RarityName { get; set; }

        private bool dataLoaded => (monsters is not null && breeds is not null);
        private bool notFound = false;

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            RarityName = Uri.UnescapeDataString(RarityName);
            if (Enum.IsDefined(typeof(MonsterRarity), RarityName) || Enum.IsDefined(typeof(MonsterRarity), int.Parse(RarityName)))
            {
                var _rarity = Enum.Parse<MonsterRarity>(RarityName);
                RarityName = _rarity.ToJsonString();
                monsters = await DataService.GetMonstersByRarityAsync(_rarity);
                breeds = (await DataService.GetBreedsByRarityAsync(_rarity)) ?? [];
            }

            notFound = (monsters is null);
        }
    }
}
