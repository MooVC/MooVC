namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static IEnumerable<T> TryGetInternalEnumerable<T>(this SerializationInfo info, string name)
        {
            return info.TryGetInternalEnumerable<T>(name, new T[0]);
        }

        [return: NotNullIfNotNull("defaultValue")]
        public static IEnumerable<T>? TryGetInternalEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T>? defaultValue)
        {
            return info.TryGetEnumerable(FormatName(name), defaultValue);
        }
    }
}