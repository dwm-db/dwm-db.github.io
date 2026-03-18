using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Components.Monsters;

public partial class MonsterResistancesComponent
{
    [Parameter]
    public required Monster? monster { get; set; }

    [Parameter]
    public required bool includeNames { get; set; } = false;

    [Parameter]
    public bool halfSize { get; set; } = false;

    private string css => halfSize ? "col-2 col-sm-2 col-md-3 col-lg-2 col-xl-2 col-xxl-2" : "col-2 col-sm-2 col-md-2 col-lg-1 col-xl-1 col-xxl-1";

    private bool dataLoaded => monster is not null;

    private string ConvertAttribute(SkillAttribute attribute)
    {
        if (monster is null)
            return ConvertResistance(MonsterResistanceTier.NONE);

        return attribute switch
        {
            SkillAttribute.A => ConvertResistance(monster!.Resistances.A),
            SkillAttribute.B => ConvertResistance(monster!.Resistances.B),
            SkillAttribute.C => ConvertResistance(monster!.Resistances.C),
            SkillAttribute.D => ConvertResistance(monster!.Resistances.D),
            SkillAttribute.E => ConvertResistance(monster!.Resistances.E),
            SkillAttribute.F => ConvertResistance(monster!.Resistances.F),
            SkillAttribute.G => ConvertResistance(monster!.Resistances.G),
            SkillAttribute.H => ConvertResistance(monster!.Resistances.H),
            SkillAttribute.I => ConvertResistance(monster!.Resistances.I),
            SkillAttribute.J => ConvertResistance(monster!.Resistances.J),
            SkillAttribute.K => ConvertResistance(monster!.Resistances.K),
            SkillAttribute.L => ConvertResistance(monster!.Resistances.L),
            SkillAttribute.M => ConvertResistance(monster!.Resistances.M),
            SkillAttribute.N => ConvertResistance(monster!.Resistances.N),
            SkillAttribute.O => ConvertResistance(monster!.Resistances.O),
            SkillAttribute.P => ConvertResistance(monster!.Resistances.P),
            SkillAttribute.Q => ConvertResistance(monster!.Resistances.Q),
            SkillAttribute.R => ConvertResistance(monster!.Resistances.R),
            SkillAttribute.S => ConvertResistance(monster!.Resistances.S),
            SkillAttribute.T => ConvertResistance(monster!.Resistances.T),
            SkillAttribute.U => ConvertResistance(monster!.Resistances.U),
            SkillAttribute.V => ConvertResistance(monster!.Resistances.V),
            SkillAttribute.W => ConvertResistance(monster!.Resistances.W),
            SkillAttribute.X => ConvertResistance(monster!.Resistances.X),
            SkillAttribute.Y => ConvertResistance(monster!.Resistances.Y),
            SkillAttribute.Z => ConvertResistance(monster!.Resistances.Z),
            SkillAttribute.Æ => ConvertResistance(monster!.Resistances.Æ),
            _ => ConvertResistance(MonsterResistanceTier.NONE)
        };

        string ConvertResistance(MonsterResistanceTier tier)
        {
            return tier switch
            {
                MonsterResistanceTier.IMMUNE => "\uF586 \uF586 \uF586",
                MonsterResistanceTier.STRONG => "\uF586 \uF586 \uF588",
                MonsterResistanceTier.WEAK => "\uF586 \uF588 \uF588",
                _ => "\uF588 \uF588 \uF588",
            };
        }
    }
}