namespace WonderEgg.Core.Models;

public sealed record Breed
{
    [JsonPropertyName("monster")]
    public required Monster Target { get; set; }

    [JsonPropertyName("bases")]
    public required BreedRequirement[] Bases { get; set; } = [];

    [JsonPropertyName("mates")]
    public required BreedRequirement[] Mates { get; set; } = [];
}

public sealed record BreedRequirement
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required BreedRequirementType Type { get; set; }

    [JsonPropertyName("family")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MonsterFamily? Name { get; set; }

    [JsonPropertyName("monster")]
    public Monster? Monster { get; set; }
}

public enum BreedRequirementType
{
    [JsonStringEnumMemberName("Family")]
    Family,
    [JsonStringEnumMemberName("Monster")]
    Monster
}
