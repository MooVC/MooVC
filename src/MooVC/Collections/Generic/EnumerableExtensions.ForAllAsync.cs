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
    /// Executes an asynchronous operation for each element in an enumerable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="items"/>.</typeparam>
    /// <param name="items">The sequence of elements to iterate over.</param>
    /// <param name="operation">The asynchronous operation to execute for each element.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="operation"/> is null.</exception>
    /// <exception cref="AggregateException">At least one of the executed operations threw an exception.</exception>
    public static async Task ForAllAsync<T>(this IEnumerable<T>? items, Func<T, Task> operation)
    {
        if (items is { })
        {
            _ = IsNotNull(operation, message: EnumerableExtensionsForAllAsyncOperationRequired);

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

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}