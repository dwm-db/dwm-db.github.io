namespace DWM_Library;

public static class Extensions
{
    public static string ToJsonString(this Enum value)
    {
        Type type = value.GetType();

        // Get the field info for the specific enum member
        FieldInfo? fieldInfo = type.GetField(value.ToString());

        if (fieldInfo is not null)
        {
            // Check for the JsonStringEnumMemberName attribute
            var attribute = fieldInfo.GetCustomAttribute<JsonStringEnumMemberNameAttribute>(false);

            if (attribute != null && !string.IsNullOrEmpty(attribute.Name))
            {
                return attribute.Name; // Return the custom name
            }
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
            // Check for the JsonStringEnumMemberName attribute
            var attribute = field.GetCustomAttribute<JsonStringEnumMemberNameAttribute>(false);

            if (attribute != null && !string.IsNullOrEmpty(attribute.Name))
            {
                values = [.. values, attribute.Name]; // Add the custom name
            }
            else
            {
                // Fall back to the default enum name if the attribute is not present or empty
                values = [.. values, field.Name];
            }
        }

        return values;
    }
}
