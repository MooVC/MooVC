namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public abstract class FireAndForget
    : IEmitDiagnostics
{
    private readonly IDiagnosticsRelay diagnostics;
    private readonly Level level;

    protected FireAndForget(Level level)
    {
        diagnostics = new DiagnosticsRelay(this);
        this.level = level;
    }

    public event DiagnosticsEmittedAsyncEventHandler DiagnosticsEmitted
    {
        add => diagnostics.DiagnosticsEmitted += value;
        remove => diagnostics.DiagnosticsEmitted -= value;
    }

    [Fact]
    public void GivenACancellationTokenAndAMessageThenTheCancellationTokenAndTheMessageAreEmitted()
    {
        var cancellation = new CancellationTokenSource();
        string expected = $"Message {0} {1}";

        GivenParametersThenTheExpectedValuesAreEmitted(
            EmitWithCancellationTokenAndMessage,
            expected,
            args: new object[] { DateTime.UtcNow, DateTime.UtcNow.Ticks },
            cancellationToken: cancellation.Token);
    }

    [Fact]
    public void GivenACauseAndAMessageThenTheCauseAndMessageAreEmitted()
    {
        var cause = new ArgumentException();
        string expected = $"Message  {0} {1}";

        GivenParametersThenTheExpectedValuesAreEmitted(
            EmitWithCauseAndMessage,
            expected,
            args: new object[] { DateTime.UtcNow, DateTime.UtcNow.Ticks },
            cause: cause);
    }

    [Fact]
    public void GivenAllThenAllValuesAreEmitted()
    {
        var cancellation = new CancellationTokenSource();
        var cause = new ArgumentException();
        string expected = $"Message  {0} {1}";

        GivenParametersThenTheExpectedValuesAreEmitted(
            EmitWithAll,
            expected,
            cancellationToken: cancellation.Token,
            args: new object[] { DateTime.UtcNow, DateTime.UtcNow.Ticks },
            cause: cause);
    }

    [Fact]
    public void GivenAMessageThenTheMessageIsEmitted()
    {
        string expected = $"Message  {0} {1}";

        GivenParametersThenTheExpectedValuesAreEmitted(EmitWithMessage, expected, args: new object[] { DateTime.UtcNow, DateTime.UtcNow.Ticks });
    }

    protected abstract void EmitWithAll(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args);

    protected abstract void EmitWithCancellationTokenAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args);

    protected abstract void EmitWithCauseAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args);

    protected abstract void EmitWithMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args);

    protected void GivenParametersThenTheExpectedValuesAreEmitted(
        Action<IDiagnosticsRelay?, string, CancellationToken?, Exception?, object[]> emitter,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        bool wasEmitted = false;
        DiagnosticsEmittedAsyncEventArgs? emitted = default;

        Task EmittedAsync(IEmitDiagnostics sender, DiagnosticsEmittedAsyncEventArgs e)
        {
            wasEmitted = true;
            emitted = e;

            return Task.CompletedTask;
        }

        diagnostics.DiagnosticsEmitted += EmittedAsync;

        emitter(diagnostics, message, cancellationToken, cause, args);

        diagnostics.DiagnosticsEmitted -= EmittedAsync;

        Assert.True(wasEmitted);
        Assert.NotNull(emitted);
        Assert.Equal(cancellationToken.GetValueOrDefault(), emitted.CancellationToken);
        Assert.Equal(cause, emitted.Cause);
        Assert.Equal(message, emitted.Message.Description);
        Assert.Equal(level, emitted.Level);
        Assert.Equal(args, emitted.Message.Arguments);
    }
}