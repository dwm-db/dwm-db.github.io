using Microsoft.AspNetCore.Components;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Components.Skills;

public partial class SkillCombinationComponent
{
    [Parameter]
    public required Skill skill { get; set; }

    [Parameter]
    public required Skill currentSkill { get; set; }

    private bool dataLoaded => combo is not null && combo.CombinesFrom is not null && combo.CombinesFrom.Length > 0;
    private Combination? combo;

    protected override async Task OnParametersSetAsync()
    {
        combo = await DataService.GetCombinationByNameAsync(skill.Name);
    }
}
