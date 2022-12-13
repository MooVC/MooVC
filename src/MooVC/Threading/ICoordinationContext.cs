namespace MooVC.Threading;

using System;

/// <summary>
/// Represents the context in which coordination has been applied.
/// </summary>
/// <typeparam name="T">The type in which the coordination context applies.</typeparam>
public interface ICoordinationContext<T>
    : IDisposable
    where T : notnull
{
    /// <summary>
    /// Gets the instance on which coordination has been applied.
    /// </summary>
    T Context { get; }

    /// <summary>
    /// Gets the duration for which coordination has been applied.
    /// </summary>
    TimeSpan Duration { get; }

    /// <summary>
    /// Gets the timestamp when the coordination started.
    /// </summary>
    DateTimeOffset TimeStamp { get; }
}