namespace DWM_Library.Services;

public sealed record Monster
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("family")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required FamilyName Family { get; set; }

    [JsonPropertyName("size")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MonsterSize? Size { get; set; }

    [JsonPropertyName("rarity")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MonsterRarity? Rarity { get; set; }

    [JsonPropertyName("growths")]
    public required MonsterGrowths Growths { get; set; }

    [JsonPropertyName("resistances")]
    public required MonsterResistances Resistances { get; set; }

    [JsonPropertyName("locations")]
    public MonsterLocation[] Locations { get; set; } = [];

    [JsonPropertyName("skills")]
    public required Skill[] Skills { get; set; }
}

public sealed record MonsterGrowths
{
    [JsonPropertyName("lvl")]
    public int LVL { get; set; } = 0;

    [JsonPropertyName("exp")]
    public int EXP { get; set; } = 0;

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

public sealed record MonsterResistances
{
    public ResistanceTier A { get; set; }
    public ResistanceTier B { get; set; }
    public ResistanceTier C { get; set; }
    public ResistanceTier D { get; set; }
    public ResistanceTier E { get; set; }
    public ResistanceTier F { get; set; }
    public ResistanceTier G { get; set; }
    public ResistanceTier H { get; set; }
    public ResistanceTier I { get; set; }
    public ResistanceTier J { get; set; }
    public ResistanceTier K { get; set; }
    public ResistanceTier L { get; set; }
    public ResistanceTier M { get; set; }
    public ResistanceTier N { get; set; }
    public ResistanceTier O { get; set; }
    public ResistanceTier P { get; set; }
    public ResistanceTier Q { get; set; }
    public ResistanceTier R { get; set; }
    public ResistanceTier S { get; set; }
    public ResistanceTier T { get; set; }
    public ResistanceTier U { get; set; }
    public ResistanceTier V { get; set; }
    public ResistanceTier W { get; set; }
    public ResistanceTier X { get; set; }
    public ResistanceTier Y { get; set; }
    public ResistanceTier Z { get; set; }
    public ResistanceTier Æ { get; set; }
}

public sealed record MonsterLocation
{
    [JsonPropertyName("name")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required LocationType Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LocationVersion Version { get; set; } = LocationVersion.Both;
}

