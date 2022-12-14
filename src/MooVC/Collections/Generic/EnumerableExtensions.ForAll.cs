namespace MooVC.Collections.Generic;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}"/>.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Provides Parallel.ForEach-like behavior in the form of a LINQ extension, enumerating the elements of <paramref name="items"/> in parallel
    /// and invoking <paramref name="action"/> for each element encountered.
    /// The extension guarentees that every element of <paramref name="items"/> will be enumerated, even if one or more elements results
    /// in an exception being thrown by <paramref name="action"/>.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
    /// <param name="items">The enumeration to be enumerated.</param>
    /// <param name="action">The action to be called for each element of the enumeration.</param>
    /// <exception cref="AggregateException">One or more elements resulted in an exception being thrown by <paramref name="action"/>.</exception>
    /// <exception cref="ArgumentNullException">The <paramref name="action"/> is null.</exception>
    public static void ForAll<T>(this IEnumerable<T>? items, Action<T> action)
    {
        if (items is { })
        {
            _ = IsNotNull(action, message: EnumerableExtensionsForAllActionRequired);

            var exceptions = new ConcurrentQueue<Exception>();

            _ = Parallel.ForEach(
                items,
                item =>
                {
                    try
                    {
                        action(item);
                    }
                    catch (Exception ex)
                    {
                        exceptions.Enqueue(ex);
                    }
                });

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}