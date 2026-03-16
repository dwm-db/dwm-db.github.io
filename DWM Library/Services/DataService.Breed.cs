namespace DWM_Library.Services;

public partial class DataService : IDataService
{
    public async Task<Breed[]?> GetBreedsAsync(CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Breeds?.OrderBy(breed => breed.Target.Id).ToArray();
    }

    public async Task<Breed[]?> GetBreedsByMonsterAsync(string monsterName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Breeds?.Where(breed =>
        {
            if (string.Equals(breed.Target.Name, monsterName, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (breed.Bases is not null && breed.Bases.Length > 0 &&
                breed.Bases.Any(breedBase => breedBase.Type == RequirementType.Monster && string.Equals(breedBase.Monster?.Name, monsterName, StringComparison.InvariantCultureIgnoreCase)))
                return true;
            if (breed.Mates is not null && breed.Mates.Length > 0 &&
                breed.Mates.Any(breedMate => breedMate.Type == RequirementType.Monster && string.Equals(breedMate.Monster?.Name, monsterName, StringComparison.InvariantCultureIgnoreCase)))
                return true;

            return false;
        }).OrderBy(breed => breed.Target.Id).ToArray();
    }

    public async Task<Breed[]?> GetBreedsByFamilyAsync(string familyName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return LibraryData?.Breeds?.Where(breed =>
        {
            if (breed.Bases is not null && breed.Bases.Length > 0 &&
                breed.Bases.Any(breedBase => breedBase.Type == RequirementType.Family && string.Equals(breedBase.Name?.ToJsonString(), familyName, StringComparison.InvariantCultureIgnoreCase)))
                return true;
            if (breed.Mates is not null && breed.Mates.Length > 0 &&
                breed.Mates.Any(breedMate => breedMate.Type == RequirementType.Family && string.Equals(breedMate.Name?.ToJsonString(), familyName, StringComparison.InvariantCultureIgnoreCase)))
                return true;

            return false;
        }).OrderBy(breed => breed.Target.Id).ToArray();
    }

    public async Task<Breed[]?> GetBreedsByLocationAsync(string locationName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        var monsters = await GetMonstersByLocationAsync(locationName, cancellationToken);

        return await GetBreedsFromMonsterList(monsters, cancellationToken);
    }

    public async Task<Breed[]?> GetBreedsBySizeAsync(string sizeName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        var monsters = await GetMonstersBySizeAsync(sizeName, cancellationToken);

        return await GetBreedsFromMonsterList(monsters, cancellationToken);
    }

    public async Task<Breed[]?> GetBreedsByRarityAsync(string rarityName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        var monsters = await GetMonstersByRarityAsync(rarityName, cancellationToken);

        return await GetBreedsFromMonsterList(monsters, cancellationToken);
    }

    private async Task<Breed[]?> GetBreedsFromMonsterList(Monster[]? monsters, CancellationToken cancellationToken)
    {
        Breed[]? breeds = null;
        foreach (var monster in monsters!)
        {
            var newBreeds = (await GetBreedsByMonsterAsync(monster.Name, cancellationToken)) ?? [];
            breeds = [.. (breeds ?? []), .. newBreeds.Where(breed => breed.Target.Id != monster.Id)];
        }

        return breeds?.OrderBy(breed => breed.Target.Id).Distinct().ToArray();
    }
}
