namespace MooVC.Serialization;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using static System.String;

public static partial class SerializationInfoExtensions
{
    public static string TryGetString(this SerializationInfo info, string name)
    {
        return info.TryGetString(name, Empty);
    }

    [return: NotNullIfNotNull("defaultValue")]
    public static string? TryGetString(this SerializationInfo info, string name, string? defaultValue)
    {
        return info.TryGetValue(name, defaultValue: defaultValue);
    }
}