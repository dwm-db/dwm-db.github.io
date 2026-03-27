namespace WonderEgg.WebApp.Layouts;

public partial class FooterLayout
{
    private static readonly OrderedDictionary<string, string> NavigationLinks = new()
    {
        { "Monsters", "monster" },
        { "Families", "family" },
        { "Locations", "location" },
        { "Skills", "skill" },
        { "Json", "json" }
    };
}