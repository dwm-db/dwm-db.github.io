using WonderEgg.Core.Models;
using WonderEgg.Core.Service;

namespace WonderEgg.Core;

public partial class DataService : IDataService
{
    public async Task<Skill[]?> GetSkillsAsync(CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills?.OrderBy(skill => skill.Id).ToArray();
    }

    public async Task<Skill?> GetSkillByNameAsync(string skillName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills.FirstOrDefault(skill => string.Equals(skill.Name, skillName, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<Skill[]?> GetSkillsByTypeAsync(SkillType type, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills.Where(skill => skill.Type == type).OrderBy(skill => skill.Id).ToArray();
    }

    public async Task<Skill[]?> GetSkillsByAttributeAsync(SkillAttribute attribute, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills.Where(skill => skill.Attribute == attribute).OrderBy(skill => skill.Id).ToArray();
    }

    public async Task<Skill[]?> GetSkillsByCategoryAsync(SkillCategory category, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills.Where(skill => skill.Category == category).OrderBy(skill => skill.Id).ToArray();
    }
}
