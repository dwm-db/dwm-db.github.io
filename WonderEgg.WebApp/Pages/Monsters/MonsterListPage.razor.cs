namespace WonderEgg.WebApp.Pages.Monsters;

public partial class MonsterListPage
{
    [SupplyParameterFromQuery(Name = "family")]
    public string? FamilyFilter { get; set; }

    [SupplyParameterFromQuery(Name = "size")]
    public string? SizeFilter { get; set; }

    [SupplyParameterFromQuery(Name = "rarity")]
    public string? RarityFilter { get; set; }

    [SupplyParameterFromQuery(Name = "sortBy")]
    public string? SortBy { get; set; }

    [SupplyParameterFromQuery(Name = "sortOrder")]
    public string? SortOrder { get; set; }

    private MonsterFamily? familyFilter = null;
    private MonsterSize? sizeFilter = null;
    private MonsterRarity? rarityFilter = null;
    private SortByOptions sortByOption = SortByOptions.ID;
    private SortOrderOptions sortOrderOption = SortOrderOptions.ASC;
    private string filterText = string.Empty;
    private Monster[]? monsters;

    protected override async Task OnInitializedAsync()
    {
        monsters = await DataService.GetMonstersAsync();
    }

    protected override void OnParametersSet()
    {
        if (FamilyFilter is not null)
        {
            FamilyFilter = Uri.UnescapeDataString(FamilyFilter).ToUpperInvariant();

            if (Enum.IsDefined(typeof(MonsterFamily), FamilyFilter) || Enum.IsDefined(typeof(MonsterFamily), int.TryParse(FamilyFilter, out var value) ? value : string.Empty))
            {
                familyFilter = Enum.Parse<MonsterFamily>(FamilyFilter);
            }
        }

        if (SizeFilter is not null)
        {
            SizeFilter = Uri.UnescapeDataString(SizeFilter).ToUpperInvariant();

            if (Enum.IsDefined(typeof(MonsterSize), SizeFilter) || Enum.IsDefined(typeof(MonsterSize), int.TryParse(SizeFilter, out var value) ? value : string.Empty))
            {
                sizeFilter = Enum.Parse<MonsterSize>(SizeFilter);
            }
        }

        if (RarityFilter is not null)
        {
            RarityFilter = Uri.UnescapeDataString(RarityFilter).ToUpperInvariant();

            if (Enum.IsDefined(typeof(MonsterRarity), RarityFilter) || Enum.IsDefined(typeof(MonsterRarity), int.TryParse(RarityFilter, out var value) ? value : string.Empty))
            {
                rarityFilter = Enum.Parse<MonsterRarity>(RarityFilter);
            }
        }

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
        var monsterList = monsters?.Where(monster => monster.Name.Contains(filterText, StringComparison.InvariantCultureIgnoreCase));

        if (familyFilter is not null)
            monsterList = monsterList?.Where(monster => monster.Family == familyFilter);

        if (sizeFilter is not null)
            monsterList = monsterList?.Where(monster => monster.Size == sizeFilter);

        if (rarityFilter is not null)
            monsterList = monsterList?.Where(monster => monster.Rarity == rarityFilter);

        monsterList = sortByOption switch
        {
            SortByOptions.ID when (sortOrderOption == SortOrderOptions.ASC) => monsterList?.OrderBy(monster => monster.Id),
            SortByOptions.ID when (sortOrderOption == SortOrderOptions.DESC) => monsterList?.OrderByDescending(monster => monster.Id),
            SortByOptions.NAME when (sortOrderOption == SortOrderOptions.ASC) => monsterList?.OrderBy(monster => monster.Name),
            SortByOptions.NAME when (sortOrderOption == SortOrderOptions.DESC) => monsterList?.OrderByDescending(monster => monster.Name),
            _ => monsterList
        };

        return monsterList?.ToArray();
    }

    private void SetOption(MonsterFamily? option)
    {
        familyFilter = option;
    }

    private bool IsSelected(MonsterFamily? option)
    {
        return (familyFilter == option);
    }

    private void SetOption(MonsterSize? option)
    {
        sizeFilter = option;
    }

    private bool IsSelected(MonsterSize? option)
    {
        return (sizeFilter == option);
    }

    private void SetOption(MonsterRarity? option)
    {
        rarityFilter = option;
    }

    private bool IsSelected(MonsterRarity? option)
    {
        return (rarityFilter == option);
    }

    private void SetOption(SortByOptions option)
    {
        sortByOption = option;
    }

    private bool IsSelected(SortByOptions option)
    {
        return (sortByOption == option);
    }

    private void SetOption(SortOrderOptions option)
    {
        sortOrderOption = option;
    }

    private bool IsSelected(SortOrderOptions option)
    {
        return (sortOrderOption == option);
    }

    private enum SortByOptions
    {
        ID,
        NAME
    }
    private enum SortOrderOptions
    {
        ASC,
        DESC
    }
}
