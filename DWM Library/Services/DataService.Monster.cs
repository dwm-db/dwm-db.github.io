namespace DWM_Library.Services;

public partial class DataService : IDataService
{
    public async Task<Monster[]?> GetMonstersAsync(CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Monsters?.OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster?> GetMonsterByNameAsync(string monsterName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Monsters?.FirstOrDefault(monster => string.Equals(monster.Name.ToString(), monsterName, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<Monster[]?> GetMonstersByFamilyAsync(string familyName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Monsters?.Where(monster => string.Equals(monster.Family.ToJsonString(), familyName, StringComparison.InvariantCultureIgnoreCase)).OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster[]?> GetMonstersBySkillAsync(string skillName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Monsters?.Where(monster => monster.Skills is not null && monster.Skills.Any(skill => string.Equals(skill.Name, skillName, StringComparison.InvariantCultureIgnoreCase))).OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster[]?> GetMonstersByLocationAsync(string locationName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Monsters?.Where(monster => monster.Locations is not null && monster.Locations.Any(location => string.Equals(location.Name.ToJsonString(), locationName, StringComparison.InvariantCultureIgnoreCase))).OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster[]?> GetMonstersBySizeAsync(string sizeName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Monsters?.Where(monster => monster.Size is not null && string.Equals(monster.Size.ToJsonString(), sizeName, StringComparison.InvariantCultureIgnoreCase)).OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster[]?> GetMonstersByRarityAsync(string rarityName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Monsters?.Where(monster => monster.Rarity is not null && string.Equals(monster.Rarity.ToJsonString(), rarityName, StringComparison.InvariantCultureIgnoreCase)).OrderBy(monster => monster.Id).ToArray();
    }
}
