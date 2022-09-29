namespace MooVC.Diagnostics.DiagnosticsEmittedEventArgsTests;

using System;
using MooVC.Serialization;
using Xunit;

public sealed class WhenDiagnosticsEmittedEventArgsIsSerialized
{
    private const string DefaultMessage = "Something something Dark Side";

    [Theory]
    [InlineData(new object[] { false, Impact.Recoverable, Level.Critical, DefaultMessage })]
    [InlineData(new object[] { false, Impact.Unrecoverable, Level.Debug, DefaultMessage })]
    [InlineData(new object[] { false, Impact.Negligible, Level.Error, DefaultMessage })]
    [InlineData(new object[] { true, Impact.None, Level.Information, DefaultMessage })]
    [InlineData(new object[] { true, Impact.Recoverable, Level.Trace, "" })]
    [InlineData(new object[] { true, Impact.Unrecoverable, Level.Warning, DefaultMessage })]
    public void GivenAnInstanceThenAllPropertiesAreSerialized(bool cause, Impact impact, Level level, string? message)
    {
        var original = new DiagnosticsEmittedAsyncEventArgs(
            cause: cause ? new InvalidOperationException(message) : default,
            impact: impact,
            level: level,
            message: message);

        DiagnosticsEmittedAsyncEventArgs deserialized = original.Clone();

        Assert.Equal(original.Cause?.Message, deserialized.Cause?.Message);
        Assert.Equal(original.Impact, deserialized.Impact);
        Assert.Equal(original.Level, deserialized.Level);
        Assert.Equal(original.Message, deserialized.Message);
        Assert.NotSame(original, deserialized);
    }
}