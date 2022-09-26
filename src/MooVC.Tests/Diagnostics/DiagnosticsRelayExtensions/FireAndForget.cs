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
        string expected = $"Message {DateTime.UtcNow}, {DateTime.Today.Ticks}";

        GivenParametersThenTheExpectedValuesAreEmitted(EmitWithCancellationTokenAndMessage, expected, cancellationToken: cancellation.Token);
    }

    [Fact]
    public void GivenACauseAndAMessageThenTheCauseAndMessageAreEmitted()
    {
        var cause = new ArgumentException();
        string expected = $"Message {DateTime.UtcNow}, {DateTime.Today.Ticks}";

        GivenParametersThenTheExpectedValuesAreEmitted(EmitWithCauseAndMessage, expected, cause: cause);
    }

    [Fact]
    public void GivenAllThenAllValuesAreEmitted()
    {
        var cancellation = new CancellationTokenSource();
        var cause = new ArgumentException();
        string expected = $"Message {DateTime.UtcNow}, {DateTime.Today.Ticks}";

        GivenParametersThenTheExpectedValuesAreEmitted(
            EmitWithAll,
            expected,
            cancellationToken: cancellation.Token,
            cause: cause);
    }

    [Fact]
    public void GivenAMessageThenTheMessageIsEmitted()
    {
        string expected = $"Message {DateTime.UtcNow}, {DateTime.Today.Ticks}";

        GivenParametersThenTheExpectedValuesAreEmitted(EmitWithMessage, expected);
    }

    protected abstract void EmitWithAll(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default);

    protected abstract void EmitWithCancellationTokenAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default);

    protected abstract void EmitWithCauseAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default);

    protected abstract void EmitWithMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default);

    protected void GivenParametersThenTheExpectedValuesAreEmitted(
        Action<IDiagnosticsRelay?, string, CancellationToken?, Exception?> emitter,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        bool wasEmitted = false;

        Task EmittedAsync(IEmitDiagnostics sender, DiagnosticsEmittedAsyncEventArgs e)
        {
            Assert.Equal(cancellationToken.GetValueOrDefault(), e.CancellationToken);
            Assert.Equal(cause, e.Cause);
            Assert.Equal(message, e.Message);
            Assert.Equal(level, e.Level);

            wasEmitted = true;

            return Task.CompletedTask;
        }

        diagnostics.DiagnosticsEmitted += EmittedAsync;

        emitter(diagnostics, message, cancellationToken, cause);

        diagnostics.DiagnosticsEmitted -= EmittedAsync;

        Assert.True(wasEmitted);
    }
}