namespace DWM_Library.Services;

public sealed record Combination
{
    [JsonPropertyName("skill")]
    public required Skill Skill { get; set; }

    [JsonPropertyName("upgradesFrom")]
    public Skill? UpgradesFrom { get; set; }

    [JsonIgnore]
    public Skill? UpgradesTo { get; set; }

    [JsonPropertyName("combinesFrom")]
    public Skill[]? CombinesFrom { get; set; }

    [JsonIgnore]
    public Skill[]? CombinesTo { get; set; }
}
