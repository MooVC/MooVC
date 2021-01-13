namespace MooVC.Serialization
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using static System.String;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddString(
            this SerializationInfo info,
            string name,
            [NotNullWhen(true)] string? value,
            string? defaultValue = default,
            Func<string?, bool>? predicate = default)
        {
            predicate ??= input => !(IsNullOrEmpty(input) || input!.Equals(defaultValue));

            return info.TryAddValue(name, value, predicate: predicate);
        }
    }
}