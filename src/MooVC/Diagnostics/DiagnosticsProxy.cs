namespace MooVC.Diagnostics;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Represents a default implementation of the <see cref="IDiagnosticsProxy"/> interface, used for emitting diagnostics messages.
/// </summary>
public sealed class DiagnosticsProxy
    : IDiagnosticsProxy
{
    private static readonly Lazy<DiagnosticsProxy> @default = new(() => new DiagnosticsProxy());

    private static readonly IDictionary<Impact, Level> standard = new Dictionary<Impact, Level>
    {
        { Impact.None, Level.Information },
        { Impact.Negligible, Level.Warning },
        { Impact.Recoverable, Level.Error },
        { Impact.Unrecoverable, Level.Critical },
    };

    private readonly IDictionary<Impact, Level> defaults;

    /// <summary>
    /// Initializes a new instance of the <see cref="DiagnosticsProxy"/> class with the specified default impact-level mappings.
    /// </summary>
    /// <param name="defaults">The default impact-level mappings to use. If not provided, a standard set of mappings will be used.</param>
    public DiagnosticsProxy(IDictionary<Impact, Level>? defaults = default)
    {
        this.defaults = defaults ?? standard;
    }

    /// <summary>
    /// An event that is raised when an diagnostic related occurance is encountered.
    /// </summary>
    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    /// <summary>
    /// Gets the default <see cref="DiagnosticsProxy"/> instance.
    /// </summary>
    /// <value>
    /// The default <see cref="DiagnosticsProxy"/> instance.
    /// </value>
    public static DiagnosticsProxy Default => @default.Value;

    /// <summary>
    /// Gets the diagnostic level assigned by the proxy based on the perceived impact.
    /// </summary>
    /// <param name="impact">The perceived <see cref="Impact" /> of the event.</param>
    /// <returns>The diagnostic level assigned by the proxy based on the perceived impact.</returns>
    public Level this[Impact impact]
    {
        get
        {
            if (defaults.TryGetValue(impact, out Level level))
            {
                return level;
            }

            return Level.Error;
        }
    }

    /// <summary>
    /// Emits a diagnostic event asynchronously if the proxy deems it appropriate.
    /// </summary>
    /// <param name="source">The object emitting the event for the purpose of diagnostics.</param>
    /// <param name="cause">The <see cref="Exception" /> that caused the diagnostic event to be emitted, if any.</param>
    /// <param name="impact">The perceived <see cref="Impact" /> of the event from the perspective of the <paramref name="source"/>.</param>
    /// <param name="level">The perceived <see cref="Level" /> of the event from the perspective of the <paramref name="source"/>.</param>
    /// <param name="message">A <see cref="DiagnosticsMessage" />, providing a friendly description of the event, if any.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// The result of the task is an object containing information about the emitted diagnostic message, or null if the message was not emitted.
    /// </returns>
    public async Task<DiagnosticsEmittedAsyncEventArgs?> TryEmitAsync(
        IEmitDiagnostics source,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default,
        CancellationToken cancellationToken = default)
    {
        if (level.HasValue)
        {
            impact ??= Impact.None;
        }
        else
        {
            if (!impact.HasValue)
            {
                impact = cause is null
                    ? Impact.None
                    : Impact.Negligible;
            }

            level = this[impact.Value];
        }

        DiagnosticsEmittedAsyncEventArgs? diagnostics = default;

        if (level > Level.Ignore)
        {
            diagnostics = new DiagnosticsEmittedAsyncEventArgs(
                cause: cause,
                impact: impact.Value,
                level: level.Value,
                message: message,
                cancellationToken: cancellationToken);

            await DiagnosticsEmitted
                .PassiveInvokeAsync(source, diagnostics)
                .ConfigureAwait(false);
        }

        return diagnostics;
    }
}