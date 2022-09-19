namespace MooVC.Diagnostics.DiagnosticsRelayTests;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public sealed class WhenEmitAsyncIsCalled
    : IEmitDiagnostics
{
    private readonly IDiagnosticsRelay diagnostics;

    public WhenEmitAsyncIsCalled()
    {
        diagnostics = new DiagnosticsRelay(this);
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

        var diagnostics = new DiagnosticsRelay(
            this,
            diagnostics: new DiagnosticsProxy(defaults: new Dictionary<Impact, Level>
            {
                { Impact.None, Level.Critical },
                { Impact.Negligible, Level.Information },
            }));

        await AssertAsync(cause, default, default, message, impact, level, diagnostics: diagnostics);
    }

    private async Task AssertAsync(
        Exception? cause,
        Impact? impact,
        Level? level,
        string? message,
        Impact expectedImpact,
        Level expectedLevel,
        IDiagnosticsRelay? diagnostics = default)
    {
        const int ExpectedEmissions = 1;

        var token = new CancellationToken(false);

        int emissions = 0;

        diagnostics ??= this.diagnostics;

        diagnostics.DiagnosticsEmitted += (sender, e) =>
        {
            Assert.Same(this, sender);
            Assert.Equal(cause, e.Cause);
            Assert.Equal(token, e.CancellationToken);
            Assert.Equal(expectedImpact, e.Impact);
            Assert.Equal(expectedLevel, e.Level);
            Assert.Equal(message, e.Message);

            emissions++;

            return Task.CompletedTask;
        };

        await diagnostics.EmitAsync(cancellationToken: token, cause: cause, impact: impact, level: level, message: message);

        Assert.Equal(ExpectedEmissions, emissions);
    }
}