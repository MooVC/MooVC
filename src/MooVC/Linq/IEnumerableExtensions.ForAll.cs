namespace MooVC.Linq;

using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using static MooVC.Linq.IEnumerableExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Provides Parallel.ForEach-like behavior in the form of a LINQ extension, enumerating the elements of <paramref name="items" /> in parallel
    /// and invoking <paramref name="action" /> for each element encountered.
    /// The extension guarentees that every element of <paramref name="items" /> will be enumerated, even if one or more elements results
    /// in an exception being thrown by <paramref name="action" />.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
    /// <param name="items">The enumeration to be enumerated.</param>
    /// <param name="action">The action to be called for each element of the enumeration.</param>
    /// <exception cref="AggregateException">One or more elements resulted in an exception being thrown by <paramref name="action" />.</exception>
    /// <exception cref="ArgumentNullException">The <paramref name="action" /> is <see langword="null" />.</exception>
    public static void ForAll<T>(this IEnumerable<T>? items, Action<T> action)
    {
        if (items is not null)
        {
            _ = Guard.Against.Null(action, message: ForAllActionRequired);

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

            if (!exceptions.IsEmpty)
            {
                throw new AggregateException(exceptions);
            }
        }
    }

    /// <summary>
    /// Executes an asynchronous operation for each element in an enumerable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="items" />.</typeparam>
    /// <param name="items">The sequence of elements to iterate over.</param>
    /// <param name="operation">The asynchronous operation to execute for each element.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="operation" /> is <see langword="null" />.</exception>
    /// <exception cref="AggregateException">At least one of the executed operations threw an exception.</exception>
    public static async Task ForAll<T>(this IEnumerable<T>? items, Func<T, Task> operation)
    {
        if (items is not null)
        {
            _ = Guard.Against.Null(operation, message: ForAllAsyncOperationRequired);

            var exceptions = new ConcurrentQueue<Exception>();

            IEnumerable<Task> operations = items
                .Select(async item =>
                {
                    try
                    {
                        await operation(item)
                            .ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        exceptions.Enqueue(ex);
                    }
                })
                .ToArray();

            await Task
                .WhenAll(operations)
                .ConfigureAwait(false);

            if (!exceptions.IsEmpty)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}