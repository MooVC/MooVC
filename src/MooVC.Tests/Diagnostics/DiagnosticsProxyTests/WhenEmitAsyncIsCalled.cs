namespace MooVC.Diagnostics.DiagnosticsProxyTests;

using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public sealed class WhenEmitAsyncIsCalled
    : IEmitDiagnostics
{
    private readonly IDiagnosticsProxy diagnostics;

    public WhenEmitAsyncIsCalled()
    {
        diagnostics = new DiagnosticsProxy();
    }

    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted
    {
        add => diagnostics.DiagnosticsEmitted += value;
        remove => diagnostics.DiagnosticsEmitted -= value;
    }

    [Fact]
    public async Task GivenALevelThenTheDiagnosticsEmittedContainTheLevelAsync()
    {
        const string Message = "Something something dark side";
        const Level Level = Level.Critical;

        var cause = new InvalidOperationException();
        var token = new CancellationToken(false);

        bool wasEmitted = false;

        DiagnosticsEmitted += (sender, e) =>
        {
            Assert.Same(this, sender);
            Assert.Same(cause, e.Cause);
            Assert.Equal(token, e.CancellationToken);
            Assert.Equal(Level, e.Level);
            Assert.Equal(Message, e.Message);

            wasEmitted = true;

            return Task.CompletedTask;
        };

        await diagnostics.EmitAsync(this, cancellationToken: token, cause: cause, level: Level, message: Message);

        Assert.True(wasEmitted);
    }

    [Theory]
    [InlineData(Level.Critical)]
    [InlineData(Level.Debug)]
    [InlineData(Level.Information)]
    [InlineData(Level.Trace)]
    [InlineData(Level.Warning)]
    public async Task GivenNoLevelThenTheDiagnosticsEmittedContainTheDefaultLevelSpecificedAsync(Level @default)
    {
        var cause = new InvalidOperationException();
        string message = $"Something something dark side {@default}";
        var proxy = new DiagnosticsProxy(@default: @default);
        var token = new CancellationToken(false);

        bool wasEmitted = false;

        proxy.DiagnosticsEmitted += (sender, e) =>
        {
            Assert.Same(this, sender);
            Assert.Same(cause, e.Cause);
            Assert.Equal(token, e.CancellationToken);
            Assert.Equal(@default, e.Level);
            Assert.Equal(message, e.Message);

            wasEmitted = true;

            return Task.CompletedTask;
        };

        await proxy.EmitAsync(this, cancellationToken: token, cause: cause, message: message);

        Assert.True(wasEmitted);
    }
}