namespace MooVC;

using System;
using System.Threading;

/// <summary>
/// Represents a class that provides event data for async events.
/// </summary>
public class AsyncEventArgs
    : EventArgs
{
    private static readonly Lazy<AsyncEventArgs> empty = new(() => new AsyncEventArgs());

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncEventArgs"/> class
    /// with the specified cancellation token.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token associated with this event.</param>
    protected AsyncEventArgs(CancellationToken? cancellationToken = default)
    {
        CancellationToken = cancellationToken.GetValueOrDefault();
    }

    /// <summary>
    /// Gets the cancellation token associated with this event.
    /// </summary>
    /// <value>
    /// The cancellation token associated with this event.
    /// </value>
    public CancellationToken CancellationToken { get; }

    /// <summary>
    /// Gets an empty instance of the <see cref="AsyncEventArgs"/> class
    /// with the specified cancellation token.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token associated with this event.</param>
    /// <returns>An empty instance of the <see cref="AsyncEventArgs"/> class.</returns>
    public static new AsyncEventArgs Empty(CancellationToken? cancellationToken = default)
    {
        if (cancellationToken is { })
        {
            return new AsyncEventArgs(cancellationToken: cancellationToken);
        }

        return empty.Value;
    }
}