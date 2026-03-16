namespace DWM_Library.Services;

public sealed record LibraryData
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

public enum FamilyName
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
    RARITY_0_0,
    [JsonStringEnumMemberName("⯪☆☆☆")]
    RARITY_0_5,
    [JsonStringEnumMemberName("★☆☆☆")]
    RARITY_1_0,
    [JsonStringEnumMemberName("★⯪☆☆")]
    RARITY_1_5,
    [JsonStringEnumMemberName("★★☆☆")]
    RARITY_2_0,
    [JsonStringEnumMemberName("★★⯪☆")]
    RARITY_2_5,
    [JsonStringEnumMemberName("★★★☆")]
    RARITY_3_0,
    [JsonStringEnumMemberName("★★★⯪")]
    RARITY_3_5,
    [JsonStringEnumMemberName("★★★★")]
    RARITY_4_0
}

public enum ResistanceTier
{
    NONE = 0,
    WEAK = 1,
    STRONG = 2,
    IMMUNE = 3
}

public enum RequirementType
{
    [JsonStringEnumMemberName("Family")]
    Family,
    [JsonStringEnumMemberName("Monster")]
    Monster
}

public enum LocationType
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

public enum LocationVersion
{
    [JsonStringEnumMemberName("Both")]
    Both,
    [JsonStringEnumMemberName("Cobi")]
    Cobi,
    [JsonStringEnumMemberName("Tara")]
    Tara
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
