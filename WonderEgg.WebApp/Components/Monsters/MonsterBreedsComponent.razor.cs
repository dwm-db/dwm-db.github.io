namespace WonderEgg.WebApp.Components.Monsters;

public partial class MonsterBreedsComponent
{
    [Parameter]
    public required Breed[]? breeds { get; set; }

    [Parameter]
    public required bool includeTargets { get; set; } = false;
}