using Microsoft.AspNetCore.Components;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Components.Skills;

public partial class SkillInfoComponent
{
    [Parameter]
    public required Skill? skill { get; set; }

    [Parameter]
    public required Combination[]? upgradeGroup { get; set; }

    private bool dataLoaded => skill is not null;
}
