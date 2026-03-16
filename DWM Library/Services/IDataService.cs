namespace DWM_Library.Services;

public interface IDataService
{
    Task<LibraryData?> GetLibraryDataAsync(CancellationToken cancellationToken = default);

    Task<Breed[]?> GetBreedsAsync(CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsByMonsterAsync(string monsterName, CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsByFamilyAsync(string familyName, CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsByLocationAsync(string locationName, CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsBySizeAsync(string sizeName, CancellationToken cancellationToken = default);
    Task<Breed[]?> GetBreedsByRarityAsync(string rarityName, CancellationToken cancellationToken = default);

    Task<Monster[]?> GetMonstersAsync(CancellationToken cancellationToken = default);
    Task<Monster?> GetMonsterByNameAsync(string monsterName, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersByFamilyAsync(string familyName, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersBySkillAsync(string skillName, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersByLocationAsync(string locationName, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersBySizeAsync(string sizeName, CancellationToken cancellationToken = default);
    Task<Monster[]?> GetMonstersByRarityAsync(string rarityName, CancellationToken cancellationToken = default);

    Task<Skill[]?> GetSkillsAsync(CancellationToken cancellationToken = default);
    Task<Skill?> GetSkillByNameAsync(string skillName, CancellationToken cancellationToken = default);
    Task<Skill[]?> GetSkillsByTypeAsync(string typeName, CancellationToken cancellationToken = default);
    Task<Skill[]?> GetSkillsByAttributeAsync(string attributeName, CancellationToken cancellationToken = default);
    Task<Skill[]?> GetSkillsByCategoryAsync(string categoryName, CancellationToken cancellationToken = default);

    Task<Combination[]?> GetCombinationsAsync(CancellationToken cancellationToken = default);
    Task<Combination?> GetCombinationByNameAsync(string skillName, CancellationToken cancellationToken = default);
    Task<Combination[]?> GetSkillsByUpgradeGroupAsync(string skillName, CancellationToken cancellationToken = default);
}
