using Microsoft.AspNetCore.Components;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Components.Skills;

public partial class SkillDetailColumnComponent
{
    [Parameter]
    public required Skill skill { get; set; }

    [Parameter]
    public required Skill currentSkill { get; set; }

    private bool dataLoaded => upgradeGroup is not null && upgradeGroup.Length > 0;
    private Combination[]? upgradeGroup;

    protected override async Task OnParametersSetAsync()
    {
        upgradeGroup = await DataService.GetSkillsByUpgradeGroupAsync(skill.Name) ?? [];
    }
}
