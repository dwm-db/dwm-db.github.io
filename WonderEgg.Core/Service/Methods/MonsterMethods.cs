using WonderEgg.Core.Models;
using WonderEgg.Core.Service;

namespace WonderEgg.Core;

public partial class DataService : IDataService
{
    public async Task<Monster[]?> GetMonstersAsync(CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Monsters?.OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster?> GetMonsterByNameAsync(string monsterName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Monsters?.FirstOrDefault(monster => string.Equals(monster.Name.ToString(), monsterName, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<Monster[]?> GetMonstersBySkillAsync(string skillName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Monsters?.Where(monster => monster.Skills is not null && monster.Skills.Any(skill => string.Equals(skill.Name, skillName, StringComparison.InvariantCultureIgnoreCase))).OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster[]?> GetMonstersByFamilyAsync(MonsterFamily family, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Monsters?.Where(monster => monster.Family == family).OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster[]?> GetMonstersByLocationAsync(MonsterLocationType location, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Monsters?.Where(monster => monster.Locations is not null && monster.Locations.Any(loc => loc.Name == location)).OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster[]?> GetMonstersBySizeAsync(MonsterSize size, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Monsters?.Where(monster => monster.Size is not null && monster.Size == size).OrderBy(monster => monster.Id).ToArray();
    }

    public async Task<Monster[]?> GetMonstersByRarityAsync(MonsterRarity rarity, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Monsters?.Where(monster => monster.Rarity is not null && monster.Rarity == rarity).OrderBy(monster => monster.Id).ToArray();
    }
}
