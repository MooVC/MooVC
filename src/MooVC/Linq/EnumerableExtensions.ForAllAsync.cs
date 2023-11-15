namespace MooVC.Linq;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using static MooVC.Linq.EnumerableExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Executes an asynchronous operation for each element in an enumerable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="items" />.</typeparam>
    /// <param name="items">The sequence of elements to iterate over.</param>
    /// <param name="operation">The asynchronous operation to execute for each element.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="operation" /> is <see langword="null" />.</exception>
    /// <exception cref="AggregateException">At least one of the executed operations threw an exception.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task ForAllAsync<T>(this IEnumerable<T>? items, Func<T, Task> operation)
    {
        if (items is not null)
        {
            _ = Guard.Against.Null(operation, parameterName: nameof(operation), message: ForAllAsyncOperationRequired);

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