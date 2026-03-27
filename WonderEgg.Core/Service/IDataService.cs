using WonderEgg.Core.Models;

namespace WonderEgg.Core.Service;

public interface IDataService
{
    Task<Breed[]?> GetBreedsAsync(CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsByMonsterAsync(string monsterName, CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsByFamilyAsync(MonsterFamily family, CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsByLocationAsync(MonsterLocationType location, CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsBySizeAsync(MonsterSize size, CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsByRarityAsync(MonsterRarity rarity, CancellationToken cancellationToken = default);

    Task<Monster[]?> GetMonstersAsync(CancellationToken cancellationToken = default);
    Task<Monster?> GetMonsterByNameAsync(string monsterName, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersBySkillAsync(string skillName, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersByFamilyAsync(MonsterFamily family, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersByLocationAsync(MonsterLocationType location, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersBySizeAsync(MonsterSize size, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersByRarityAsync(MonsterRarity rarity, CancellationToken cancellationToken = default);

    Task<Skill[]?> GetSkillsAsync(CancellationToken cancellationToken = default);
    Task<Skill?> GetSkillByNameAsync(string skillName, CancellationToken cancellationToken = default);
    Task<Skill[]?> GetSkillsByTypeAsync(SkillType type, CancellationToken cancellationToken = default);
    Task<Skill[]?> GetSkillsByAttributeAsync(SkillAttribute attribute, CancellationToken cancellationToken = default);
    Task<Skill[]?> GetSkillsByCategoryAsync(SkillCategory category, CancellationToken cancellationToken = default);

    Task<Combination[]?> GetCombinationsAsync(CancellationToken cancellationToken = default);
    Task<Combination?> GetCombinationByNameAsync(string skillName, CancellationToken cancellationToken = default);
    Task<Combination[]?> GetSkillsByUpgradeGroupAsync(string skillName, CancellationToken cancellationToken = default);
}
