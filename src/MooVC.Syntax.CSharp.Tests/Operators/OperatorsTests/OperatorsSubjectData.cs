namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Immutable;

internal static class OperatorsSubjectData
{
    public static Operators Create(
        ImmutableArray<Binary>? binaries = default,
        ImmutableArray<Comparison>? comparisons = default,
        ImmutableArray<Conversion>? conversions = default,
        ImmutableArray<Unary>? unaries = default)
    {
        return new Operators
        {
            Binaries = binaries ?? ImmutableArray<Binary>.Empty,
            Comparisons = comparisons ?? ImmutableArray<Comparison>.Empty,
            Conversions = conversions ?? ImmutableArray<Conversion>.Empty,
            Unaries = unaries ?? ImmutableArray<Unary>.Empty,
        };
    }
}
