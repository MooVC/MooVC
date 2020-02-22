namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MooVC.Linq;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> value)
        {
            if (value.SafeAny())
            {
                info.AddEnumerable(name, value);

                return true;
            }

            return false;
        }
    }
}