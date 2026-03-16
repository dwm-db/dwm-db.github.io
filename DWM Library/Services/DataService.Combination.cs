namespace DWM_Library.Services;

public partial class DataService : IDataService
{
    public async Task<Combination[]?> GetCombinationsAsync(CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Combinations?.OrderBy(combo => combo.Skill.Id).ToArray();
    }

    public async Task<Combination?> GetCombinationByNameAsync(string skillName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Combinations.FirstOrDefault(combo => string.Equals(combo.Skill.Name, skillName, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<Combination[]?> GetSkillsByUpgradeGroupAsync(string skillName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        var upgradeGroup = LibraryData?.Combinations.Where(combo =>
        {
            return string.Equals(combo.Skill.Name, skillName, StringComparison.InvariantCultureIgnoreCase)
                || string.Equals(combo.UpgradesTo?.Name, skillName, StringComparison.InvariantCultureIgnoreCase)
                || string.Equals(combo.UpgradesFrom?.Name, skillName, StringComparison.InvariantCultureIgnoreCase);
        }).ToArray();

        if (upgradeGroup is null)
            return null;

        upgradeGroup = GetSkillUpgradeGroup(upgradeGroup);

        var previousSkill = upgradeGroup.First(skill => string.IsNullOrWhiteSpace(skill.UpgradesFrom?.Name));
        Combination[] sortedSkills = [previousSkill];

        while (!string.IsNullOrWhiteSpace(previousSkill.UpgradesTo?.Name))
        {
            previousSkill = upgradeGroup.First(skill => string.Equals(skill.Skill.Name, previousSkill.UpgradesTo?.Name, StringComparison.InvariantCultureIgnoreCase));
            sortedSkills = [.. sortedSkills, previousSkill];
        }

        upgradeGroup = [.. sortedSkills];

        return upgradeGroup;
    }

    private Combination[] GetSkillUpgradeGroup(Combination[] upgradeGroup)
    {
        bool loop;
        do
        {
            loop = false;
            var skills = upgradeGroup.ToList();

            upgradeGroup.ToList()
            .ForEach(skill =>
            {
                LibraryData?.Combinations.Where(combo =>
                {
                    return string.Equals(combo.Skill.Name, skill.Skill.Name, StringComparison.InvariantCultureIgnoreCase)
                        || string.Equals(combo.UpgradesTo?.Name, skill.Skill.Name, StringComparison.InvariantCultureIgnoreCase)
                        || string.Equals(combo.UpgradesFrom?.Name, skill.Skill.Name, StringComparison.InvariantCultureIgnoreCase);
                })
                .ToList().ForEach(x =>
                {
                    if (!skills.Any(y => string.Equals(x.Skill.Name, y.Skill.Name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        skills.Add(x);
                        loop = true;
                    }
                });
            });

            upgradeGroup = [.. skills];

        } while (loop);

        return upgradeGroup;
    }
}
