namespace MooVC.Serialization
{
    using System;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddInternalValue<T>(
            this SerializationInfo info,
            string name,
            T value,
            T defaultValue = default,
            Func<T, bool>? predicate = default)
        {
            return info.TryAddValue(FormatName(name), value, defaultValue: defaultValue, predicate: predicate);
        }
    }
}