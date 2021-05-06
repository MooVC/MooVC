namespace MooVC.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddInternalEnumerable<T>(
            this SerializationInfo info,
            string name,
            [NotNullWhen(true)] IEnumerable<T>? value,
            Func<IEnumerable<T>, bool>? predicate = default)
        {
            return info.TryAddEnumerable(FormatName(name), value, predicate: predicate);
        }
    }
}