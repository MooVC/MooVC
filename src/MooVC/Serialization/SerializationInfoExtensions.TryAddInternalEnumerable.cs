namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddInternalEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> value)
        {
            return info.TryAddEnumerable(FormatName(name), value);
        }
    }
}