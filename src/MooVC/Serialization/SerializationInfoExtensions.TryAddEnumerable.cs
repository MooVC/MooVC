namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using MooVC.Linq;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> value)
        {
            if (value.SafeAny())
            {
                info.AddValue(name, value.ToArray());

                return true;
            }

            return false;
        }
    }
}