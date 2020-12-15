namespace MooVC.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using MooVC.Linq;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddEnumerable<T>(
            this SerializationInfo info,
            string name,
            [NotNullWhen(true)] IEnumerable<T>? value,
            Func<IEnumerable<T>, bool>? predicate = default)
        {
            if (value is { })
            {
                predicate ??= input => input.SafeAny();

                if (predicate(value))
                {
                    info.AddEnumerable(name, value);

                    return true;
                }
            }

            return false;
        }
    }
}