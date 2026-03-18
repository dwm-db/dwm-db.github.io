using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Skills
{
    public partial class SkillPage
    {
        [Parameter]
        public required string SkillName { get; set; }

        private bool dataLoaded => (skill is not null);
        private bool notFound = false;

        private Skill? skill;
        private Combination[]? upgradeGroup;

        protected override async Task OnParametersSetAsync()
        {
            SkillName = Uri.UnescapeDataString(SkillName);

            skill = await DataService.GetSkillByNameAsync(SkillName);
            upgradeGroup = (await DataService.GetSkillsByUpgradeGroupAsync(SkillName)) ?? [];

            notFound = (skill is null);
        }

        private bool combinesFrom => (skill is not null && upgradeGroup is not null && upgradeGroup?.FirstOrDefault(combo => combo.Skill.Id == skill.Id && combo.CombinesFrom is not null && combo.CombinesFrom.Length > 0) is not null);
        private bool combinesTo => (skill is not null && upgradeGroup is not null && (upgradeGroup?.Any(combo => combo.CombinesTo is not null && combo.CombinesTo.Length > 0) ?? false));

        private Monster[]? GetMonsters()
        {
            if (upgradeGroup is not null && upgradeGroup.Length > 1)
            {
                return upgradeGroup?.Select(combo => combo.Skill)?.Where(skill => skill.Monsters is not null && skill.Monsters.Length > 0)?.SelectMany(skill => skill.Monsters!)?.OrderBy(monster => monster.Id)?.ToArray();
            }

            return skill?.Monsters?.OrderBy(monster => monster.Id)?.ToArray();
        }
    }
}
