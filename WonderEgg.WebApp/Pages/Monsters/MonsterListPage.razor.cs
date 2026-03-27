using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Monsters;

public partial class MonsterListPage
{
    [SupplyParameterFromQuery(Name = "sortBy")]
    public string? SortBy { get; set; }

    [SupplyParameterFromQuery(Name = "sortOrder")]
    public string? SortOrder { get; set; }

    private SortByOptions sortByOption = SortByOptions.DEFAULT;
    private SortOrderOptions sortOrderOption = SortOrderOptions.DEFAULT;
    private Monster[]? monsters;

    protected override async Task OnInitializedAsync()
    {
        monsters = await DataService.GetMonstersAsync();
    }

    protected override void OnParametersSet()
    {
        if (SortBy is not null)
        {
            SortBy = Uri.UnescapeDataString(SortBy).ToUpperInvariant();

            if (Enum.IsDefined(typeof(SortByOptions), SortBy) || Enum.IsDefined(typeof(SortByOptions), int.TryParse(SortBy, out var value) ? value : string.Empty))
            {
                sortByOption = Enum.Parse<SortByOptions>(SortBy);
            }
        }

        if (SortOrder is not null)
        {
            SortOrder = Uri.UnescapeDataString(SortOrder).ToUpperInvariant();

            if (Enum.IsDefined(typeof(SortOrderOptions), SortOrder) || Enum.IsDefined(typeof(SortOrderOptions), int.TryParse(SortOrder, out var value) ? value : string.Empty))
            {
                sortOrderOption = Enum.Parse<SortOrderOptions>(SortOrder);
            }
        }
    }

    private Monster[]? GetMonsters()
    {
        return sortByOption switch
        {
            SortByOptions.DEFAULT when (sortOrderOption == SortOrderOptions.DEFAULT) => monsters?.OrderBy(monster => monster.Id)?.ToArray(),
            SortByOptions.DEFAULT when (sortOrderOption == SortOrderOptions.REVERSE) => monsters?.OrderByDescending(monster => monster.Id)?.ToArray(),
            SortByOptions.NAME when (sortOrderOption == SortOrderOptions.DEFAULT) => monsters?.OrderBy(monster => monster.Name)?.ToArray(),
            SortByOptions.NAME when (sortOrderOption == SortOrderOptions.REVERSE) => monsters?.OrderByDescending(monster => monster.Name)?.ToArray(),
            SortByOptions.SIZE when (sortOrderOption == SortOrderOptions.DEFAULT) => monsters?.OrderBy(monster => monster.Size)?.ToArray(),
            SortByOptions.SIZE when (sortOrderOption == SortOrderOptions.REVERSE) => monsters?.OrderByDescending(monster => monster.Size)?.ToArray(),
            SortByOptions.RARITY when (sortOrderOption == SortOrderOptions.DEFAULT) => monsters?.OrderBy(monster => monster.Rarity)?.ToArray(),
            SortByOptions.RARITY when (sortOrderOption == SortOrderOptions.REVERSE) => monsters?.OrderByDescending(monster => monster.Rarity)?.ToArray(),
            _ => monsters
        };
    }

    private void SetOption(SortByOptions option)
    {
        sortByOption = option;
    }

    private void SetOption(SortOrderOptions option)
    {
        sortOrderOption = option;
    }

    private string GetCSS(SortByOptions option)
    {
        return "dropdown-item pb-2" + ((sortByOption == option) ? " active" : null);
    }

    private bool IsSelected(SortByOptions option)
    {
        return (sortByOption == option);
    }

    private bool IsSelected(SortOrderOptions option)
    {
        return (sortOrderOption == option);
    }

    private enum SortByOptions
    {
        DEFAULT,
        NAME,
        SIZE,
        RARITY
    }
    private enum SortOrderOptions
    {
        DEFAULT,
        REVERSE
    }
}
