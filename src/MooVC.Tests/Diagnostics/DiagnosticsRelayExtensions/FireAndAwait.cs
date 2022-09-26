namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public abstract class FireAndAwait
    : IEmitDiagnostics
{
    private readonly IDiagnosticsRelay diagnostics;
    private readonly Level level;

    protected FireAndAwait(Level level)
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
    public Task GivenACancellationTokenAndAMessageThenTheCancellationTokenAndTheMessageAreEmittedAsync()
    {
        var cancellation = new CancellationTokenSource();
        string expected = $"Message {DateTime.UtcNow}, {DateTime.Today.Ticks}";

        return GivenParametersThenTheExpectedValuesAreEmittedAsync(
            EmitWithCancellationTokenAndMessageAsync,
            expected,
            cancellationToken: cancellation.Token);
    }

    [Fact]
    public Task GivenACauseAndAMessageThenTheCauseAndMessageAreEmittedAsync()
    {
        var cause = new ArgumentException();
        string expected = $"Message {DateTime.UtcNow}, {DateTime.Today.Ticks}";

        return GivenParametersThenTheExpectedValuesAreEmittedAsync(EmitWithCauseAndMessageAsync, expected, cause: cause);
    }

    [Fact]
    public Task GivenAllThenAllValuesAreEmittedAsync()
    {
        var cancellation = new CancellationTokenSource();
        var cause = new ArgumentException();
        string expected = $"Message {DateTime.UtcNow}, {DateTime.Today.Ticks}";

        return GivenParametersThenTheExpectedValuesAreEmittedAsync(
            EmitWithAllAsync,
            expected,
            cancellationToken: cancellation.Token,
            cause: cause);
    }

    [Fact]
    public Task GivenAMessageThenTheMessageIsEmittedAsync()
    {
        string expected = $"Message {DateTime.UtcNow}, {DateTime.Today.Ticks}";

        return GivenParametersThenTheExpectedValuesAreEmittedAsync(EmitWithMessageAsync, expected);
    }

    protected abstract Task EmitWithAllAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default);

    protected abstract Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default);

    protected abstract Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default);

    protected abstract Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default);

    protected async Task GivenParametersThenTheExpectedValuesAreEmittedAsync(
        Func<IDiagnosticsRelay?, string, CancellationToken?, Exception?, Task> emitter,
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

        await emitter(diagnostics, message, cancellationToken, cause);

        diagnostics.DiagnosticsEmitted -= EmittedAsync;

        Assert.True(wasEmitted);
    }
}