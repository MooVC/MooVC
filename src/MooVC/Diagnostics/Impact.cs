namespace MooVC.Diagnostics;

/// <summary>
/// An enumeration of impacts from the perspective of the emitter.
/// </summary>
public enum Impact
    : byte
{
    /// <summary>
    /// No impact.
    /// </summary>
    None = 0,

    /// <summary>
    /// A negligible impact, likely addressed automatically.
    /// </summary>
    Negligible = 1,

    /// <summary>
    /// A recoverable impact, likely requiring the originator to retry.
    /// </summary>
    Recoverable = 2,

    /// <summary>
    /// An unrecoverable impact, likely requiring alternative action.
    /// </summary>
    Unrecoverable = 3,
}