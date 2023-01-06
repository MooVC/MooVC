namespace MooVC.Diagnostics;

/// <summary>
/// Represents an object that can emit diagnostics.
/// </summary>
public interface IEmitDiagnostics
{
    /// <summary>
    /// An event that is raised when an diagnostic related occurance is encountered.
    /// </summary>
    event DiagnosticsEmittedAsyncEventHandler DiagnosticsEmitted;
}