namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static IEnumerable<T> TryGetInternalEnumerable<T>(this SerializationInfo info, string name)
        {
            return info.TryGetEnumerable<T>(FormatName(name));
        }

        public static IEnumerable<T> TryGetInternalEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> defaultValue)
        {
            return info.TryGetEnumerable(FormatName(name), defaultValue);
        }
    }
}