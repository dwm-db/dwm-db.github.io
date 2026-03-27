using Microsoft.AspNetCore.Components;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Components.Skills;

public partial class SkillUpgradePathComponent
{
    [Parameter]
    public required Combination[] upgradeGroup { get; set; }

    [Parameter]
    public required Skill currentSkill { get; set; }
}
