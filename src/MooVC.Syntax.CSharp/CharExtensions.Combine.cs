namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Immutable;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.StringExtensions_Resources;

    internal static partial class CharExtensions
    {
        public static string Combine(this char separator, params string[] values)
        {
            _ = Guard.Against.Null(separator, message: CombineSeparatorRequired);

            return separator.ToString().Combine(values);
        }

        public static string Combine<T>(this char separator, ImmutableArray<T> elements, Func<T, string> formatter)
        {
            _ = Guard.Against.Null(separator, message: CombineSeparatorRequired);

            return separator.ToString().Combine(elements, formatter);
        }
    }
}