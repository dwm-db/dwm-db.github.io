using System.Diagnostics;

namespace DWM_Library.Services;

public partial class DataService : IDataService
{
    private HttpClient HttpClient { get; init; }
    private LibraryData? LibraryData { get; set; }
    private bool DATA_NOT_LOADED => (LibraryData is null);
    private static string LIBRARY_DATA_JSON => "dwm-library-data.json";

    public DataService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private async Task LoadLibraryDataFromJsonAsync(CancellationToken cancellationToken)
    {
        try
        {
            LibraryData ??= await HttpClient.GetFromJsonAsync<LibraryData>(LIBRARY_DATA_JSON, new System.Text.Json.JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            }, cancellationToken);
        }
        catch (Exception ex)
        {
            Debugger.Break();
        }

        if (LibraryData is not null)
        {
            PopulateSkillMonsters(LibraryData.Skills, LibraryData.Monsters);
            FlattenMonsters(LibraryData.Monsters, LibraryData.Breeds);

            PopulateComboUpgradesTo(LibraryData.Combinations);
            PopulateComboCombinesTo(LibraryData.Combinations);
            FlattenSkills(LibraryData.Skills, LibraryData.Combinations);
        }

    }

    public async Task<LibraryData?> GetLibraryDataAsync(CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(LibraryData);
    }

    private static void PopulateSkillMonsters(Skill[] skills, Monster[] monsters)
    {
        bool loop;
        do
        {
            loop = false;
            skills.Where(skill => skill.Monsters is null || skill.Monsters.Length == 0).ToList()
            .ForEach(skill =>
            {
                monsters.Where(monster => monster.Skills is not null && monster.Skills.Any(linkedSkill => linkedSkill.Id == skill.Id)).ToList()
                .ForEach(monster =>
                {
                    skill.Monsters = [.. (skill.Monsters ?? []), monster];
                    loop = true;
                });
                skill.Monsters = skill.Monsters?.OrderBy(monster => monster.Id).ToArray();
            });
        } while (loop);
    }

    private static void FlattenMonsters(Monster[] monsters, Breed[] breeds)
    {
        monsters.ToList()
        .ForEach(monster =>
        {
            breeds.Where(breed => breed.Target.Id == monster.Id).ToList()
            .ForEach(breed =>
            {
                breed.Target = monster;
                breed.Target.Skills = monster.Skills;
            });
        });
    }

    private static void PopulateComboUpgradesTo(Combination[] combinations)
    {
        combinations.Where(fromCombo => fromCombo.UpgradesFrom is not null).ToList()
        .ForEach(fromCombo =>
        {
            combinations.Where(toCombo => toCombo.UpgradesTo is null && toCombo.Skill.Id == fromCombo.UpgradesFrom!.Id).ToList()
            .ForEach(toCombo =>
            {
                toCombo.UpgradesTo = fromCombo.Skill;
            });
        });
    }

    private static void PopulateComboCombinesTo(Combination[] combinations)
    {
        bool loop;
        do
        {
            loop = false;
            combinations.Where(fromCombo => fromCombo.CombinesFrom is not null && fromCombo.CombinesFrom.Length > 0).ToList()
            .ForEach(fromCombo =>
            {
                combinations.Where(toCombo => (toCombo.CombinesTo is null || (!toCombo.CombinesTo?.Any(ct => ct.Id == fromCombo.Skill.Id) ?? false)) &&
                                              (fromCombo.CombinesFrom?.Any(cf => cf.Id == toCombo.Skill.Id) ?? false)).ToList()
                .ForEach(toCombo =>
                {
                    toCombo.CombinesTo = [.. (toCombo.CombinesTo ?? []), fromCombo.Skill];
                    loop = true;
                });
            });
        } while (loop);
    }

    private static void FlattenSkills(Skill[] skills, Combination[] combinations)
    {
        skills.ToList()
        .ForEach(skill =>
        {
            combinations.Where(combo => combo.Skill.Id == skill.Id).ToList()
            .ForEach(combo =>
            {
                combo.Skill = skill;
                combo.Skill.Monsters = skill.Monsters;
            });
        });
    }
}
