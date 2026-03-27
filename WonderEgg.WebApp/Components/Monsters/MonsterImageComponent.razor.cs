namespace WonderEgg.WebApp.Components.Monsters;

public partial class MonsterImageComponent
{
    [Parameter]
    public required Monster? monster { get; set; }

    [Parameter]
    public MonsterImageSize size { get; set; } = MonsterImageSize.Small;

    [Parameter]
    public bool IsPlaceholder { get; set; } = false;

    public enum MonsterImageSize
    {
        Small = 1,
        Medium = 2,
        Large = 4,
    }

    public string css => size switch
    {
        MonsterImageSize.Large => "MonsterImage-4x",
        MonsterImageSize.Medium => "MonsterImage-2x",
        _ => "MonsterImage"
    };

    public string url => size switch
    {
        MonsterImageSize.Large when (monster is null) => "/img/4x/wonderegg-4x.png",
        MonsterImageSize.Medium when (monster is null) => "/img/2x/wonderegg-2x.png",
        _ when (monster is null) => "/img/1x/wonderegg.png",
        MonsterImageSize.Large => $"/img/4x/{monster!.Name.ToLower()}-4x.png",
        MonsterImageSize.Medium => $"/img/2x/{monster!.Name.ToLower()}-2x.png",
        _ => $"/img/1x/{monster!.Name.ToLower()}.png"
    };

    public string alt => (monster?.Name.ToString() ?? "Logo") + " pic";

    public int wh => size switch
    {
        MonsterImageSize.Large => 192,
        MonsterImageSize.Medium => 96,
        _ => 48
    };
}