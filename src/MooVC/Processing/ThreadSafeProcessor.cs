namespace MooVC.Processing;

using System.Threading;
using MooVC.Diagnostics;

/// <summary>
/// Represents a base implementation for a long running process that provides a thread safe guarentee when starting/stoping.
/// </summary>
public abstract class ThreadSafeProcessor
    : Processor
{
    private const int StartRequestedFlag = 1;
    private const int StopRequestedFlag = 0;

    private volatile int flag = StopRequestedFlag;

    /// <summary>
    /// Facilitates the Initialization of new instance based on the <see cref="ThreadSafeProcessor"/> class.
    /// </summary>
    /// <param name="diagnostics">
    /// The proxy that determines if diagnostics are to be emitted, with the default configuration used if not provided.
    /// </param>
    protected ThreadSafeProcessor(IDiagnosticsProxy? diagnostics = default)
        : base(diagnostics: diagnostics)
    {
    }

    /// <summary>
    /// Determines if the process can be started in a thread-safe manner.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the processor can be started, otherwise <c>false</c>.
    /// </returns>
    protected sealed override bool CanStart()
    {
        return Interlocked.CompareExchange(ref flag, StartRequestedFlag, StopRequestedFlag) == StopRequestedFlag;
    }

    /// <summary>
    /// Determines if the process can be stopped in a thread-safe manner.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the processor can be stopped, otherwise <c>false</c>.
    /// </returns>
    protected sealed override bool CanStop()
    {
        return Interlocked.CompareExchange(ref flag, StopRequestedFlag, StartRequestedFlag) == StartRequestedFlag;
    }
}