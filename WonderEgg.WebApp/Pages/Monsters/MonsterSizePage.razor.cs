using Microsoft.AspNetCore.Components;
using WonderEgg.Core;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Monsters
{
    public partial class MonsterSizePage
    {
        [Parameter]
        public required string SizeName { get; set; }

        private bool dataLoaded => (monsters is not null && breeds is not null);

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            SizeName = Uri.UnescapeDataString(SizeName);

            if (Enum.IsDefined(typeof(MonsterSize), SizeName) || Enum.IsDefined(typeof(MonsterSize), int.TryParse(SizeName, out var value) ? value : string.Empty))
            {
                var _size = Enum.Parse<MonsterSize>(SizeName);
                SizeName = _size.ToJsonString();
                monsters = await DataService.GetMonstersBySizeAsync(_size);
                breeds = (await DataService.GetBreedsBySizeAsync(_size)) ?? [];
            }

            if (!dataLoaded)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}
