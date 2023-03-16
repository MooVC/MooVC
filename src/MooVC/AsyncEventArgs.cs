namespace MooVC;

using System;
using Token = System.Threading.CancellationToken;

/// <summary>
/// Represents a class that provides event data for async events.
/// </summary>
public class AsyncEventArgs
    : EventArgs
{
    private static readonly Lazy<AsyncEventArgs> empty = new(() => new AsyncEventArgs());

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncEventArgs"/> class with the specified <see cref="Token"/>.
    /// </summary>
    /// <param name="cancellationToken">An optional <see cref="Token"/> associated with this event.</param>
    protected AsyncEventArgs(Token? cancellationToken = default)
    {
        CancellationToken = cancellationToken.GetValueOrDefault();
    }

    /// <summary>
    /// Gets the <see cref="CancellationToken"/> associated with this event.
    /// </summary>
    /// <value>
    /// The <see cref="CancellationToken"/> associated with this event.
    /// </value>
    public Token CancellationToken { get; }

    /// <summary>
    /// Gets an empty instance of the <see cref="AsyncEventArgs"/> class with the specified <see cref="Token"/>.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="Token"/> associated with this event.</param>
    /// <returns>An empty instance of the <see cref="AsyncEventArgs"/> class.</returns>
    public static new AsyncEventArgs Empty(Token? cancellationToken = default)
    {
        if (cancellationToken is { })
        {
            return new AsyncEventArgs(cancellationToken: cancellationToken);
        }

        return empty.Value;
    }
}