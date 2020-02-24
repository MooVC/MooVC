namespace MooVC.Serialization
{
    using System;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddValue<T>(
            this SerializationInfo info,
            string name,
            T value,
            T defaultValue = default,
            Func<T, bool>? predicate = default)
        {
            predicate ??= input => input is { } && !input.Equals(defaultValue);

            if (predicate(value))
            {
                info.AddValue(name, value);

                return true;
            }

            return false;
        }
    }
}