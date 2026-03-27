namespace WonderEgg.WebApp.Components.Monsters;

public partial class MonsterCardGridComponent
{
    [Parameter]
    public required Monster[]? monsters { get; set; }

    private bool dataLoaded => (monsters is not null && monsters.Length > 0);

    private string GetCSS(int row, int col)
    {
        var opacity = row switch
        {
            0 => " opacity-100",
            1 => " opacity-75",
            2 => " opacity-50",
            3 => " opacity-25",
            _ => " opacity-0"
        };
        var display = col switch
        {
            0 => " d-block",
            1 => " d-block",
            2 => " d-none d-md-block",
            3 => " d-none d-lg-block",
            4 => " d-none d-xl-block",
            5 => " d-none d-xxl-block",
            _ => " d-none"
        };
        return "col" + opacity + display;
    }
}