namespace MooVC.Diagnostics;

/// <summary>
/// An enumeration of diagnostics levels from the perspective of the emitter.
/// </summary>
public enum Level
    : byte
{
    /// <summary>
    /// The event is deemed critical to the operation being performed and is likely impacting in nature.
    /// </summary>
    Critical = 6,

    /// <summary>
    /// The event is deemed debug to the operation being performed and is likely informational for development purposes.
    /// </summary>
    Debug = 2,

    /// <summary>
    /// The event is deemed an error to the operation being performed and is likely impacting in nature.
    /// </summary>
    Error = 5,

    /// <summary>
    /// The event is deemed irrelevant to the operation being performed and is likely useless to any listener.
    /// </summary>
    Ignore = 0,

    /// <summary>
    /// The event is deemed debug to the operation being performed and is likely informational for diagnostics purposes.
    /// </summary>
    Information = 3,

    /// <summary>
    /// The event is deemed trace to the operation being performed and is likely informational for development purposes.
    /// </summary>
    Trace = 1,

    /// <summary>
    /// The event is deemed warning to the operation being performed and is likely informational for diagnostics purposes or may neccessitate
    /// development or operational action be taken in the future to address.
    /// </summary>
    Warning = 4,
}