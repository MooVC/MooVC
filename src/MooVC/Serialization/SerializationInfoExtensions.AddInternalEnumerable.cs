namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static void AddInternalEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> value)
        {
            info.AddEnumerable(FormatName(name), value);
        }
    }
}