namespace WonderEgg.WebApp.Components.Monsters;

public partial class MonsterGrowthsComponent
{
    [Parameter]
    public required Monster[]? monsters { get; set; }

    [Parameter]
    public required bool includeNames { get; set; } = false;

    private bool dataLoaded => monsters is not null && monsters.Length > 0;
}