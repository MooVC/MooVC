namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using System;
using System.Linq;
using Xunit;

public sealed class WhenDiagnosticsMessageIsConstructed
{
    [Theory]
    [InlineData("Something")]
    [InlineData("something")]
    [InlineData("dark")]
    [InlineData("side")]
    public void GivenADescriptionThenAMessageWithThatDescriptionIsCreated(string description)
    {
        var message = new DiagnosticsMessage(description);

        Assert.Empty(message.Arguments);
        Assert.Equal(description, message.Description);
    }

    [Theory]
    [InlineData("Something", 0)]
    [InlineData("something", 1)]
    [InlineData("dark", 2)]
    [InlineData("side", 4)]
    public void GivenADescriptionAndArgumentsThenAMessageWithTheDescriptionAndArgumentsIsCreated(string description, int arguments)
    {
        object[] expected = Enumerable
            .Range(1, arguments)
            .Select(_ => new object())
            .ToArray();

        var message = new DiagnosticsMessage(description, expected);

        Assert.Equal(expected, message.Arguments);
        Assert.Equal(description, message.Description);
    }

    [Theory]
    [InlineData(default)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenNoDescriptionThenAnArgumentExceptionIsThrown(string? description)
    {
        ArgumentException exception = Assert.ThrowsAny<ArgumentException>(() => new DiagnosticsMessage(description!));

        Assert.Equal(nameof(description), exception.ParamName);
    }
}