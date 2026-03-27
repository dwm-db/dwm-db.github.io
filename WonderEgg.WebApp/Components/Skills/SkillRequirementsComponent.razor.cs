using Microsoft.AspNetCore.Components;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Components.Skills;

public partial class SkillRequirementsComponent
{
    [Parameter]
    public required Skill[]? skills { get; set; }

    [Parameter]
    public required bool includeNames { get; set; } = false;

    private bool dataLoaded => skills is not null && skills.Length > 0;
}
