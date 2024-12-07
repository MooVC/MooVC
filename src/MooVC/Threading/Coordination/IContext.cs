namespace MooVC.Threading.Coordination;

/// <summary>
/// Represents the context in which coordination has been applied.
/// </summary>
/// <typeparam name="T">The type in which the coordination context applies.</typeparam>
public interface IContext<out T>
    : IDisposable
    where T : notnull
{
    /// <summary>
    /// Gets the duration for which coordination has been applied.
    /// </summary>
    /// <value>
    /// The duration for which coordination has been applied.
    /// </value>
    TimeSpan Duration { get; }

    /// <summary>
    /// Gets the instance on which coordination has been applied.
    /// </summary>
    /// <value>
    /// The instance on which coordination has been applied.
    /// </value>
    T Subject { get; }

    /// <summary>
    /// Gets the timestamp when the coordination started.
    /// </summary>
    /// <value>
    /// The timestamp when the coordination started.
    /// </value>
    DateTimeOffset TimeStamp { get; }
}