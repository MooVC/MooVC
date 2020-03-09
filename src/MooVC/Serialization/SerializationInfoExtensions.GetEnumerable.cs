namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static IEnumerable<T> GetEnumerable<T>(this SerializationInfo info, string name)
        {
            return (T[])info.GetValue(name, typeof(T[]));
        }
    }
}