namespace WonderEgg.Core;

public static class Extensions
{
    public static string ToJsonString(this Enum value)
    {
        Type type = value.GetType();

        // Get the field info for the specific enum member
        FieldInfo? fieldInfo = type.GetField(value.ToString());

        if (fieldInfo is not null)
        {
            return fieldInfo.GetJsonAttribute();
        }

        // Fall back to the default enum name if the attribute is not present or empty
        return value.ToString();
    }

    public static string[] GetJsonStrings(this Type type)
    {
        FieldInfo[] fieldInfo = type.GetFields();

        string[] values = [];
        foreach (var field in fieldInfo.Where(field => !field.IsSpecialName))
        {
            values = [.. values, field.GetJsonAttribute()];
        }

        return values;
    }

    public static Tuple<string, string>[] GetJsonTuples(this Type type)
    {
        FieldInfo[] fieldInfo = type.GetFields();

        Tuple<string, string>[] values = [];
        foreach (var field in fieldInfo.Where(field => !field.IsSpecialName))
        {
            //if (type.IsEnum && type.Name == nameof(MonsterRarity) && type.IsEnumDefined(field.Name))
            //{
            //    int enumValue = (int)Enum.Parse(type, field.Name);
            //    values = [.. values, new Tuple<string, string>(enumValue.ToString(), field.GetJsonAttribute())];
            //}
            //else
            //{
            //    values = [.. values, new Tuple<string, string>(field.Name, field.GetJsonAttribute())];
            //}
            values = [.. values, new Tuple<string, string>(field.Name, field.GetJsonAttribute())];
        }

        return values;
    }

    private static string GetJsonAttribute(this FieldInfo fieldInfo)
    {
        // Check for the JsonStringEnumMemberName attribute
        var attribute = fieldInfo.GetCustomAttribute<JsonStringEnumMemberNameAttribute>(false);

        if (attribute != null && !string.IsNullOrEmpty(attribute.Name))
        {
            return attribute.Name.TransformStars(); // Add the custom name
        }
        else
        {
            // Fall back to the default enum name if the attribute is not present or empty
            return fieldInfo.Name;
        }
    }

    private static string TransformStars(this string jsonString)
    {
        return jsonString.Replace("★", "\uF586 ").Replace("⯪", "\uF587 ").Replace("☆", "\uF588 ").Trim();
    }
}
