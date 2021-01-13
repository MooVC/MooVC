namespace MooVC.Serialization
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using static System.String;

    public static partial class SerializationInfoExtensions
    {
        public static string GetInternalString(this SerializationInfo info, string name)
        {
            return info.GetInternalString(name, defaultValue: Empty);
        }

        [return: NotNullIfNotNull("defaultValue")]
        public static string? GetInternalString(this SerializationInfo info, string name, string? defaultValue = default)
        {
            return info.GetString(FormatName(name));
        }
    }
}