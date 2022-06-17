namespace MooVC.Serialization;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static bool TryAddValue<T>(
        this SerializationInfo info,
        string name,
        [NotNullWhen(true)] T? value,
        T? defaultValue = default,
        Func<T, bool>? predicate = default)
    {
        if (value is { })
        {
            predicate ??= input => input is { } && !input.Equals(defaultValue);

            if (predicate(value))
            {
                info.AddValue(name, value, value.GetType());

                return true;
            }
        }

        return false;
    }
}