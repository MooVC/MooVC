namespace MooVC.Diagnostics;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

    public DiagnosticsProxy(IDictionary<Impact, Level>? defaults = default)
    {
        this.defaults = defaults ?? standard;
    }

    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    public static DiagnosticsProxy Default => @default.Value;

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

    public async Task<DiagnosticsEmittedAsyncEventArgs?> TryEmitAsync(
        IEmitDiagnostics source,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default)
    {
        if (level.HasValue)
        {
            impact ??= Impact.None;
        }
        else
        {
            if (!impact.HasValue)
            {
                impact = cause is { }
                    ? Impact.Negligible
                    : Impact.None;
            }

            level = this[impact.Value];
        }

        DiagnosticsEmittedAsyncEventArgs? diagnostics = default;

        if (level > Level.Ignore)
        {
            diagnostics = new DiagnosticsEmittedAsyncEventArgs(
                cancellationToken: cancellationToken,
                cause: cause,
                impact: impact.Value,
                level: level.Value,
                message: message);

            await DiagnosticsEmitted
                .PassiveInvokeAsync(source, diagnostics)
                .ConfigureAwait(false);
        }

        return diagnostics;
    }
}