using WonderEgg.Core.Models;
using WonderEgg.Core.Service;

namespace WonderEgg.Core;

public partial class DataService : IDataService
{
    private HttpClient HttpClient { get; init; }
    private LibraryData? Data { get; set; }

    private bool DATA_NOT_LOADED => (Data is null || Data.Skills is null || Data.Combinations is null || Data.Monsters is null || Data.Breeds is null);
    private static string LIBRARY_DATA_JSON => "dwm-db.json";
    private static System.Text.Json.JsonSerializerOptions JSON_SERIALIZER_OPTIONS => new() { ReferenceHandler = ReferenceHandler.Preserve, WriteIndented = true };

    public DataService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private async Task LoadLibraryDataFromJsonAsync(CancellationToken cancellationToken)
    {
        try
        {
            Data ??= await HttpClient.GetFromJsonAsync<LibraryData>(LIBRARY_DATA_JSON, JSON_SERIALIZER_OPTIONS, cancellationToken);
        }
        catch (Exception ex)
        {
            Debugger.Log(0, Debugger.DefaultCategory, ex.Message);
            Debugger.Break();
        }

        if (Data is not null)
        {
            PopulateSkillMonsters(Data.Skills, Data.Monsters);
            FlattenMonsters(Data.Monsters, Data.Breeds);

            PopulateComboUpgradesTo(Data.Combinations);
            PopulateComboCombinesTo(Data.Combinations);
            FlattenSkills(Data.Skills, Data.Combinations);
        }

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

    private sealed record LibraryData
    {
        [JsonPropertyName("skills")]
        public required Skill[] Skills { get; set; }

        [JsonPropertyName("combinations")]
        public required Combination[] Combinations { get; set; }

        [JsonPropertyName("monsters")]
        public required Monster[] Monsters { get; set; }

        [JsonPropertyName("breeds")]
        public required Breed[] Breeds { get; set; }
    }
}
