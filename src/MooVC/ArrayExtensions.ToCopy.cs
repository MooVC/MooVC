namespace MooVC;

using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using MooVC.Linq;
using static MooVC.ArrayExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="Array" />.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    /// Returns a snapshot of a array sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements within <paramref name="values" />.</typeparam>
    /// <param name="values">The sequence to take a snapshot of.</param>
    /// <param name="predicate">
    /// An optional function to test each element for a condition.
    /// If provided, only elements that satisfy the condition will be included in the snapshot.
    /// </param>
    /// <returns>An array that contains the elements of the snapshot.</returns>
    public static T[] ToCopy<T>(this T[] values, Func<T, bool>? predicate = default)
    {
        _ = Guard.Against.Null(values, message: ToCopyArrayRequired);

        if (values.Length == 0)
        {
            return [];
        }

        if (predicate is null)
        {
            var snapshot = new T[values.Length];

            Array.Copy(values, snapshot, values.Length);

            return snapshot;
        }

        return values
            .WhereIf(predicate is not null, predicate!)
            .ToArray();
    }
}