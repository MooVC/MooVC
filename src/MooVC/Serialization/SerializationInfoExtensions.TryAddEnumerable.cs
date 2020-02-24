namespace MooVC.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MooVC.Linq;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddEnumerable<T>(
            this SerializationInfo info,
            string name,
            IEnumerable<T> value,
            Func<IEnumerable<T>, bool>? predicate = default)
        {
            predicate ??= input => input.SafeAny();

            if (predicate(value))
            {
                info.AddEnumerable(name, value);

                return true;
            }

            return false;
        }
    }
}