namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static IEnumerable<T> TryGetInternalEnumerable<T>(this SerializationInfo info, string name)
        {
            return info.TryGetValue(FormatName(name), new T[0]);
        }
    }
}