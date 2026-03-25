namespace DWMLibrary.WebApp.Layouts;

public partial class FooterLayout
{
    private static readonly OrderedDictionary<string, string> NavigationLinks = new()
    {
        { "Monsters", "monster" },
        { "Families", "monster/family" },
        { "Locations", "monster/location" },
        { "Skills", "skill" },
        { "Json", "json" }
    };
}