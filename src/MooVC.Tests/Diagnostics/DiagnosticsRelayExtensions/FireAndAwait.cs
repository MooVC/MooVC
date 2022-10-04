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
        string expected = $"Message  {0} {1}";

        return GivenParametersThenTheExpectedValuesAreEmittedAsync(
            EmitWithCancellationTokenAndMessageAsync,
            expected,
            args: new object[] { DateTime.UtcNow, DateTime.UtcNow.Ticks },
            cancellationToken: cancellation.Token);
    }

    [Fact]
    public Task GivenACauseAndAMessageThenTheCauseAndMessageAreEmittedAsync()
    {
        var cause = new ArgumentException();
        string expected = $"Message  {0} {1}";

        return GivenParametersThenTheExpectedValuesAreEmittedAsync(
            EmitWithCauseAndMessageAsync,
            expected,
            args: new object[] { DateTime.UtcNow, DateTime.UtcNow.Ticks },
            cause: cause);
    }

    [Fact]
    public Task GivenAllThenAllValuesAreEmittedAsync()
    {
        var cancellation = new CancellationTokenSource();
        var cause = new ArgumentException();
        string expected = $"Message  {0} {1}";

        return GivenParametersThenTheExpectedValuesAreEmittedAsync(
            EmitWithAllAsync,
            expected,
            args: new object[] { DateTime.UtcNow, DateTime.UtcNow.Ticks },
            cancellationToken: cancellation.Token,
            cause: cause);
    }

    [Fact]
    public Task GivenAMessageThenTheMessageIsEmittedAsync()
    {
        string expected = $"Message  {0} {1}";

        return GivenParametersThenTheExpectedValuesAreEmittedAsync(
            EmitWithMessageAsync,
            expected,
            args: new object[] { DateTime.UtcNow, DateTime.UtcNow.Ticks });
    }

    protected abstract Task EmitWithAllAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args);

    protected abstract Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args);

    protected abstract Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args);

    protected abstract Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args);

    protected async Task GivenParametersThenTheExpectedValuesAreEmittedAsync(
        Func<IDiagnosticsRelay?, string, CancellationToken?, Exception?, object[], Task> emitter,
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

        await emitter(diagnostics, message, cancellationToken, cause, args);

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