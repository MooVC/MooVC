namespace MooVC.Diagnostics.DiagnosticsProxyTests;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public sealed class WhenTryEmitAsyncIsCalled
    : IEmitDiagnostics
{
    private readonly IDiagnosticsProxy diagnostics;

    public WhenTryEmitAsyncIsCalled()
    {
        diagnostics = DiagnosticsProxy.Default;
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

        await AssertAsync(cause, default, Level, Message, Impact.None, Level);
    }

    [Fact]
    public async Task GivenAnIgnoreLevelThenNoDiagnosticsAreEmittedAsync()
    {
        const string Message = "Something something dark side";
        const Level Level = Level.Ignore;

        var cause = new InvalidOperationException();

        await AssertAsync(cause, default, Level, Message, Impact.None, Level, isExpected: false);
    }

    [Theory]
    [InlineData(Impact.None, Level.Information)]
    [InlineData(Impact.Negligible, Level.Warning)]
    [InlineData(Impact.Recoverable, Level.Error)]
    [InlineData(Impact.Unrecoverable, Level.Critical)]
    public async Task GivenNoLevelThenTheDiagnosticsEmittedContainTheDefaultLevelAsync(Impact impact, Level level)
    {
        var cause = new InvalidOperationException();
        string message = $"Something something dark side - {impact}, {level}";

        await AssertAsync(cause, impact, default, message, impact, level);
    }

    [Theory]
    [InlineData(false, Impact.None, Level.Information)]
    [InlineData(true, Impact.Negligible, Level.Warning)]
    public async Task GivenNoLevelAndNoImpactThenTheDiagnosticsEmittedContainTheDefaultImpactAndLevelAsync(
        bool exception,
        Impact impact,
        Level level)
    {
        Exception? cause = exception
            ? new InvalidOperationException()
            : default;

        string message = $"Something something dark side - {exception}, {impact}, {level}";

        await AssertAsync(cause, default, default, message, impact, level);
    }

    [Theory]
    [InlineData(false, Impact.None, Level.Critical)]
    [InlineData(true, Impact.Negligible, Level.Information)]
    public async Task GivenNoLevelAndNoImpactWhenOverridesAreProvidedThenTheDiagnosticsEmittedContainTheDefaultImpactAndLevelAsync(
        bool exception,
        Impact impact,
        Level level)
    {
        Exception? cause = exception
            ? new InvalidOperationException()
            : default;

        string message = $"Something something dark side - {exception}, {impact}, {level}";

        var diagnostics = new DiagnosticsProxy(new Dictionary<Impact, Level>
        {
            { Impact.None, Level.Critical },
            { Impact.Negligible, Level.Information },
        });

        await AssertAsync(cause, default, default, message, impact, level, diagnostics: diagnostics);
    }

    private async Task AssertAsync(
        Exception? cause,
        Impact? impact,
        Level? level,
        string? message,
        Impact expectedImpact,
        Level expectedLevel,
        IDiagnosticsProxy? diagnostics = default,
        bool isExpected = true)
    {
        var token = new CancellationToken(false);

        bool wasEmitted = false;
        DiagnosticsEmittedAsyncEventArgs? received = default;

        diagnostics ??= this.diagnostics;

        diagnostics.DiagnosticsEmitted += (sender, e) =>
        {
            Assert.Same(this, sender);
            Assert.Equal(cause, e.Cause);
            Assert.Equal(token, e.CancellationToken);
            Assert.Equal(expectedImpact, e.Impact);
            Assert.Equal(expectedLevel, e.Level);
            Assert.Equal(message, e.Message);

            wasEmitted = true;
            received = e;

            return Task.CompletedTask;
        };

        DiagnosticsEmittedAsyncEventArgs? actual = await diagnostics.TryEmitAsync(
            this,
            cancellationToken: token,
            cause: cause,
            impact: impact,
            level: level,
            message: message);

        if (isExpected)
        {
            Assert.NotNull(actual);
            Assert.Same(received, actual);
            Assert.True(wasEmitted);
        }
        else
        {
            Assert.Null(actual);
            Assert.Null(received);
            Assert.False(wasEmitted);
        }
    }
}