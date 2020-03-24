namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static IEnumerable<T> TryGetEnumerable<T>(this SerializationInfo info, string name)
        {
            return info.TryGetEnumerable(name, new T[0]);
        }

        public static IEnumerable<T> TryGetEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> defaultValue)
        {
            return info.TryGetValue(name, defaultValue);
        }
    }
}