namespace MooVC.Serialization
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        [return: NotNullIfNotNull("defaultValue")]
        public static T? TryGetInternalValue<T>(this SerializationInfo info, string name, T? defaultValue = default)
        {
            return info.TryGetValue(FormatName(name), defaultValue: defaultValue);
        }
    }
}