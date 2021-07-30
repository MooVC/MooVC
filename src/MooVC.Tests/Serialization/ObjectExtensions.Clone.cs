namespace MooVC.Serialization
{
    using System.Collections.Generic;

    internal static partial class ObjectExtensions
    {
        public static T Clone<T>(this T original)
        {
            IEnumerable<byte> data = original.Serialize();

            return data.Deserialize<T>();
        }
    }
}