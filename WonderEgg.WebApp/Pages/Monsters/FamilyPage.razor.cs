using WonderEgg.Core;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Monsters
{
    public partial class FamilyPage
    {
        [Parameter]
        public required string FamilyName { get; set; }

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            FamilyName = Uri.UnescapeDataString(FamilyName);

            if (Enum.IsDefined(typeof(MonsterFamily), FamilyName) || Enum.IsDefined(typeof(MonsterFamily), int.TryParse(FamilyName, out var value) ? value : string.Empty))
            {
                var _family = Enum.Parse<MonsterFamily>(FamilyName);
                FamilyName = _family.ToJsonString();
                monsters = await DataService.GetMonstersByFamilyAsync(_family);
                breeds = (await DataService.GetBreedsByFamilyAsync(_family)) ?? [];
            }
            else
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}
