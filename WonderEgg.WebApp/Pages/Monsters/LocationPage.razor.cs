using WonderEgg.Core;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Monsters
{
    public partial class LocationPage
    {
        [Parameter]
        public required string LocationName { get; set; }

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            LocationName = Uri.UnescapeDataString(LocationName);

            if (Enum.IsDefined(typeof(MonsterLocationType), LocationName) || Enum.IsDefined(typeof(MonsterLocationType), int.TryParse(LocationName, out var value) ? value : string.Empty))
            {
                var _location = Enum.Parse<MonsterLocationType>(LocationName);
                LocationName = _location.ToJsonString();
                monsters = await DataService.GetMonstersByLocationAsync(_location);
                breeds = (await DataService.GetBreedsByLocationAsync(_location)) ?? [];
            }
            else
            {
                NavigationManager.NavigateTo("/404");
            }
        }

        private Monster[]? GetMonstersForVersion(MonsterLocationVersion version)
        {
            return monsters?.Where(monster =>
            {
                return monster.Locations.Any(location =>
                    {
                        return location.Version == version && string.Equals(location.Name.ToJsonString(), LocationName, StringComparison.InvariantCultureIgnoreCase);
                    });
            })?.OrderBy(monster => monster.Id)?.ToArray();
        }
    }
}
