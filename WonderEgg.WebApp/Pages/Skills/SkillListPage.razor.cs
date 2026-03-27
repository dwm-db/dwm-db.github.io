namespace WonderEgg.WebApp.Pages.Skills;

public partial class SkillListPage
{
    [SupplyParameterFromQuery(Name = "sortBy")]
    public string? SortBy { get; set; }

    [SupplyParameterFromQuery(Name = "sortOrder")]
    public string? SortOrder { get; set; }

    private SortByOptions sortByOption = SortByOptions.DEFAULT;
    private SortOrderOptions sortOrderOption = SortOrderOptions.DEFAULT;
    private string filterText = string.Empty;
    private Skill[]? skills;

    protected override async Task OnInitializedAsync()
    {
        skills = await DataService.GetSkillsAsync();
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

    private Skill[]? GetSkills()
    {
        var skillList = skills?.Where(skill => skill.Name.Contains(filterText, StringComparison.InvariantCultureIgnoreCase));
        return sortByOption switch
        {
            SortByOptions.DEFAULT when (sortOrderOption == SortOrderOptions.DEFAULT) => skillList?.OrderBy(skill => skill.Id)?.ToArray(),
            SortByOptions.DEFAULT when (sortOrderOption == SortOrderOptions.REVERSE) => skillList?.OrderByDescending(skill => skill.Id)?.ToArray(),
            SortByOptions.NAME when (sortOrderOption == SortOrderOptions.DEFAULT) => skillList?.OrderBy(skill => skill.Name)?.ToArray(),
            SortByOptions.NAME when (sortOrderOption == SortOrderOptions.REVERSE) => skillList?.OrderByDescending(skill => skill.Name)?.ToArray(),
            SortByOptions.TYPE when (sortOrderOption == SortOrderOptions.DEFAULT) => skillList?.OrderBy(skill => skill.Type)?.ToArray(),
            SortByOptions.TYPE when (sortOrderOption == SortOrderOptions.REVERSE) => skillList?.OrderByDescending(skill => skill.Type)?.ToArray(),
            SortByOptions.CATEGORY when (sortOrderOption == SortOrderOptions.DEFAULT) => skillList?.OrderBy(skill => skill.Category)?.ToArray(),
            SortByOptions.CATEGORY when (sortOrderOption == SortOrderOptions.REVERSE) => skillList?.OrderByDescending(skill => skill.Category)?.ToArray(),
            SortByOptions.ATTRIBUTE when (sortOrderOption == SortOrderOptions.DEFAULT) => skillList?.OrderBy(skill => skill.Attribute)?.ToArray(),
            SortByOptions.ATTRIBUTE when (sortOrderOption == SortOrderOptions.REVERSE) => skillList?.OrderByDescending(skill => skill.Attribute)?.ToArray(),
            _ => skillList?.ToArray()
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
        TYPE,
        CATEGORY,
        ATTRIBUTE
    }
    private enum SortOrderOptions
    {
        DEFAULT,
        REVERSE
    }
}
