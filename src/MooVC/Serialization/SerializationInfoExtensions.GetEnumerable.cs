namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static IEnumerable<T> GetEnumerable<T>(this SerializationInfo info, string name)
        {
            object? value = info.GetValue(name, typeof(T[]));

            if (value is T[] result)
            {
                return result;
            }

            return new T[0];
        }
    }
}