namespace MooVC.Diagnostics.DiagnosticsEmittedEventArgsTests;

using System;
using System.Linq;
using Xunit;

public sealed class WhenDiagnosticsEmittedEventArgsIsConstructed
{
    [Fact]
    public void GivenACauseWhenNoMessageIsProvidedThenTheMessageDefaultsToTheMessageWithinTheCause()
    {
        const string ExpectedMessage = "Something something Dark Side";

        var cause = new InvalidOperationException(ExpectedMessage);
        var value = new DiagnosticsEmittedAsyncEventArgs(cause: cause);

        Assert.Equal(cause, value.Cause);
        Assert.Equal(ExpectedMessage, value.Message);
    }

    [Fact]
    public void GivenALevelOutsideOfRangeThenTheMaxLevelIsApplied()
    {
        Level expected = Level.Trace;
        Level max = Enum.GetValues<Level>().Max();
        byte raw = (byte)max;
        var level = (Level)(raw + 1);

        var value = new DiagnosticsEmittedAsyncEventArgs(level: level, message: "Something happened");

        Assert.Equal(expected, value.Level);
    }

    [Theory]
    [InlineData(Level.Trace)]
    [InlineData(Level.Information)]
    [InlineData(Level.Critical)]
    public void GivenALevelWithinRangeThenTheLevelIsApplied(Level level)
    {
        var value = new DiagnosticsEmittedAsyncEventArgs(level: level, message: "Something happened");

        Assert.Equal(level, value.Level);
    }

    [Fact]
    public void GivenAMessageThenTheMessageIsApplied()
    {
        const string ExpectedMessage = "Something something Dark Side";

        var value = new DiagnosticsEmittedAsyncEventArgs(message: ExpectedMessage);

        Assert.Equal(ExpectedMessage, value.Message);
    }

    [Theory]
    [InlineData(default)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenAnEmptyMessageWhenACauseIsProvidedTheMessageDefaultsToTheMessageWithinTheCause(string? message)
    {
        const string ExpectedMessage = "Something something Dark Side";

        var cause = new InvalidOperationException(ExpectedMessage);
        var value = new DiagnosticsEmittedAsyncEventArgs(cause: cause, message: message);

        Assert.Equal(ExpectedMessage, value.Message);
    }

    [Theory]
    [InlineData(default)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenAnEmptyMessageWhenNoCauseIsProvidedThenAnArgumentExceptionIsThrown(string? message)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            new DiagnosticsEmittedAsyncEventArgs(message: message));

        Assert.Equal(nameof(message), exception.ParamName);
    }
}