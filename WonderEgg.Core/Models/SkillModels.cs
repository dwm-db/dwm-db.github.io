namespace WonderEgg.Core.Models;

public sealed record Skill
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required SkillType Type { get; set; }

    [JsonPropertyName("attribute")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SkillAttribute? Attribute { get; set; }

    [JsonPropertyName("category")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SkillCategory? Category { get; set; }

    [JsonPropertyName("requirements")]
    public required SkillRequirements Requirements { get; set; }

    [JsonIgnore]
    public Monster[]? Monsters { get; set; }
}

public enum SkillType
{
    [JsonStringEnumMemberName("Normal")]
    Normal,
    [JsonStringEnumMemberName("Physical")]
    Physical,
    [JsonStringEnumMemberName("Spell")]
    Spell,
    [JsonStringEnumMemberName("Breath")]
    Breath,
    [JsonStringEnumMemberName("Dance")]
    Dance,
    [JsonStringEnumMemberName("Field")]
    Field
}

public enum SkillAttribute
{
    NONE,
    A, B, C, D, E, F, G,
    H, I, J, K, L, M, N,
    O, P, Q, R, S, T, U,
    V, W, X, Y, Z, Æ
}

public enum SkillCategory
{
    NONE,
    Attack,
    Support,
    Healing
}

public sealed record SkillRequirements
{
    [JsonPropertyName("lvl")]
    public int LVL { get; set; } = 0;

    [JsonPropertyName("hp")]
    public int HP { get; set; } = 0;

    [JsonPropertyName("mp")]
    public int MP { get; set; } = 0;

    [JsonPropertyName("atk")]
    public int ATK { get; set; } = 0;

    [JsonPropertyName("def")]
    public int DEF { get; set; } = 0;

    [JsonPropertyName("agl")]
    public int AGL { get; set; } = 0;

    [JsonPropertyName("int")]
    public int INT { get; set; } = 0;
}
