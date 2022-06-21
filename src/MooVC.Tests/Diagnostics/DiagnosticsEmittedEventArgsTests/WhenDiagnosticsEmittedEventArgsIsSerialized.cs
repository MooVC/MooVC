namespace MooVC.Diagnostics.DiagnosticsEmittedEventArgsTests;

using System;
using MooVC.Serialization;
using Xunit;

public sealed class WhenDiagnosticsEmittedEventArgsIsSerialized
{
    private const string DefaultMessage = "Something something Dark Side";

    [Theory]
    [InlineData(new object[] { false, Level.Critical, "" })]
    [InlineData(new object[] { false, Level.Debug, DefaultMessage })]
    [InlineData(new object[] { false, Level.Error, "" })]
    [InlineData(new object[] { true, Level.Information, DefaultMessage })]
    [InlineData(new object[] { true, Level.Trace, "" })]
    [InlineData(new object[] { true, Level.Warning, DefaultMessage })]
    public void GivenAnInstanceThenAllPropertiesAreSerialized(bool cause, Level level, string? message)
    {
        var original = new DiagnosticsEmittedAsyncEventArgs(
            cause: cause ? new InvalidOperationException(message) : default,
            level: level,
            message: message);

        DiagnosticsEmittedAsyncEventArgs deserialized = original.Clone();

        Assert.Equal(original.Cause?.Message, deserialized.Cause?.Message);
        Assert.Equal(original.Level, deserialized.Level);
        Assert.Equal(original.Message, deserialized.Message);
        Assert.NotSame(original, deserialized);
    }
}