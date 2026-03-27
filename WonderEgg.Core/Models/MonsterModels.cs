namespace WonderEgg.Core.Models;

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
    public required MonsterFamily Family { get; set; }

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

public enum MonsterFamily
{
    [JsonStringEnumMemberName("SLIME")]
    SLIME,
    [JsonStringEnumMemberName("DRAGON")]
    DRAGON,
    [JsonStringEnumMemberName("BEAST")]
    BEAST,
    [JsonStringEnumMemberName("BIRD")]
    BIRD,
    [JsonStringEnumMemberName("PLANT")]
    PLANT,
    [JsonStringEnumMemberName("BUG")]
    BUG,
    [JsonStringEnumMemberName("DEVIL")]
    DEVIL,
    [JsonStringEnumMemberName("ZOMBIE")]
    ZOMBIE,
    [JsonStringEnumMemberName("MATERIAL")]
    MATERIAL,
    [JsonStringEnumMemberName("WATER")]
    WATER,
    [JsonStringEnumMemberName("????")]
    BOSS
}

public enum MonsterSize
{
    [JsonStringEnumMemberName("S")]
    S,
    [JsonStringEnumMemberName("M")]
    M,
    [JsonStringEnumMemberName("L")]
    L,
    [JsonStringEnumMemberName("LL")]
    LL,
    [JsonStringEnumMemberName("G")]
    G
}

public enum MonsterRarity
{
    [JsonStringEnumMemberName("☆☆☆☆")]
    NONE,
    [JsonStringEnumMemberName("⯪☆☆☆")]
    Basic,
    [JsonStringEnumMemberName("★☆☆☆")]
    Common,
    [JsonStringEnumMemberName("★⯪☆☆")]
    Uncommon,
    [JsonStringEnumMemberName("★★☆☆")]
    Rare,
    [JsonStringEnumMemberName("★★⯪☆")]
    SuperRare,
    [JsonStringEnumMemberName("★★★☆")]
    Epic,
    [JsonStringEnumMemberName("★★★⯪")]
    Legendary,
    [JsonStringEnumMemberName("★★★★")]
    Mythic
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
    public MonsterResistanceTier A { get; set; }
    public MonsterResistanceTier B { get; set; }
    public MonsterResistanceTier C { get; set; }
    public MonsterResistanceTier D { get; set; }
    public MonsterResistanceTier E { get; set; }
    public MonsterResistanceTier F { get; set; }
    public MonsterResistanceTier G { get; set; }
    public MonsterResistanceTier H { get; set; }
    public MonsterResistanceTier I { get; set; }
    public MonsterResistanceTier J { get; set; }
    public MonsterResistanceTier K { get; set; }
    public MonsterResistanceTier L { get; set; }
    public MonsterResistanceTier M { get; set; }
    public MonsterResistanceTier N { get; set; }
    public MonsterResistanceTier O { get; set; }
    public MonsterResistanceTier P { get; set; }
    public MonsterResistanceTier Q { get; set; }
    public MonsterResistanceTier R { get; set; }
    public MonsterResistanceTier S { get; set; }
    public MonsterResistanceTier T { get; set; }
    public MonsterResistanceTier U { get; set; }
    public MonsterResistanceTier V { get; set; }
    public MonsterResistanceTier W { get; set; }
    public MonsterResistanceTier X { get; set; }
    public MonsterResistanceTier Y { get; set; }
    public MonsterResistanceTier Z { get; set; }
    public MonsterResistanceTier Æ { get; set; }
}

public enum MonsterResistanceTier
{
    NONE = 0,
    WEAK = 1,
    STRONG = 2,
    IMMUNE = 3
}

public sealed record MonsterLocation
{
    [JsonPropertyName("name")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required MonsterLocationType Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MonsterLocationVersion Version { get; set; } = MonsterLocationVersion.Both;
}


public enum MonsterLocationType
{
    [JsonStringEnumMemberName("Oasis Key World")]
    Oasis,
    [JsonStringEnumMemberName("Pirate Key World")]
    Pirate,
    [JsonStringEnumMemberName("Ice Key World")]
    Ice,
    [JsonStringEnumMemberName("Sky Key World")]
    Sky,
    [JsonStringEnumMemberName("Limbo Key World")]
    Limbo,
    [JsonStringEnumMemberName("Elf Key World")]
    Elf,
    [JsonStringEnumMemberName("Lonely Key World")]
    Lonely,
    [JsonStringEnumMemberName("Traveler Key World")]
    Traveler
}

public enum MonsterLocationVersion
{
    [JsonStringEnumMemberName("Both")]
    Both,
    [JsonStringEnumMemberName("Cobi")]
    Cobi,
    [JsonStringEnumMemberName("Tara")]
    Tara
}