using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages;

public partial class JsonPage
{
    private bool dataLoaded => (data is not null && data.Skills is not null && data.Combinations is not null && data.Monsters is not null && data.Breeds is not null && json is not null);
    private static System.Text.Json.JsonSerializerOptions JSON_SERIALIZER_OPTIONS => new() { WriteIndented = false, ReferenceHandler = ReferenceHandler.Preserve };

    private JsonData? data;
    private string? json;


    protected override async Task OnInitializedAsync()
    {
        var skills = await DataService.GetSkillsAsync();
        var combinations = await DataService.GetCombinationsAsync();
        var monsters = await DataService.GetMonstersAsync();
        var breeds = await DataService.GetBreedsAsync();

        if (skills is not null && combinations is not null && monsters is not null && breeds is not null)
        {
            data = new()
            {
                Skills = skills,
                Combinations = combinations,
                Monsters = monsters,
                Breeds = breeds
            };

            try
            {
                json = System.Text.Json.JsonSerializer.Serialize(data, JSON_SERIALIZER_OPTIONS);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debugger.Log(0, System.Diagnostics.Debugger.DefaultCategory, ex.Message);
                System.Diagnostics.Debugger.Break();
            }
        }

        if (!dataLoaded)
        {
            NavigationManager.NavigateTo("/404");
        }
    }

    private sealed record JsonData
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
