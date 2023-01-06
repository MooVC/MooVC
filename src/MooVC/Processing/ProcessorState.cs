namespace MooVC.Processing;

/// <summary>
/// Represents the state of a processor.
/// </summary>
public enum ProcessorState
{
    /// <summary>
    /// The state is unknown, likely as a result of an unexpected and unrecoverable failure.
    /// </summary>
    Unknown,

    /// <summary>
    /// The processor has started and is performing its intended role.
    /// </summary>
    Started,

    /// <summary>
    /// The processor is starting and is not yet performing its intended role.
    /// </summary>
    Starting,

    /// <summary>
    /// The processor has stopped and is no longer performing its intended role.
    /// </summary>
    Stopped,

    /// <summary>
    /// The processor is stopping and may be currently performing its intended role.
    /// </summary>
    Stopping,
}