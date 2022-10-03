namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using System;
using System.Linq;
using Xunit;

public sealed class WhenImplicitlyCastFromTuple
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenAEmptyStringAndNoArgumentsThenTheEmptyInstanceIsReturned(string description)
    {
        DiagnosticsMessage message = (description, Array.Empty<object>());

        Assert.True(message.IsEmpty);
        Assert.Same(DiagnosticsMessage.Empty, message);
    }

    [Theory]
    [InlineData("Something")]
    [InlineData("something")]
    [InlineData("dark")]
    [InlineData("side...")]
    public void GivenAStringAndNoArgumentsThenAMessageIsReturnedWithTheStringSetAsTheDescription(string description)
    {
        DiagnosticsMessage message = (description, Array.Empty<object>());

        Assert.False(message.IsEmpty);
        Assert.Empty(message.Arguments);
        Assert.Equal(description, message.Description);
    }

    [Theory]
    [InlineData(1, "Something {0}")]
    [InlineData(2, "something {0} {1}")]
    [InlineData(3, "dark {0} {1} {2}")]
    [InlineData(4, "side... {0} {1} {2} {3}")]
    public void GivenAStringAndArgumentsThenAMessageIsReturnedWithTheStringSetAsTheDescriptionAndTheArgumentsApplied(
        int arguments,
        string description)
    {
        object[] expected = Enumerable
            .Range(1, arguments)
            .Cast<object>()
            .ToArray();

        DiagnosticsMessage message = (description, expected);

        Assert.False(message.IsEmpty);
        Assert.Equal(expected, message.Arguments);
        Assert.Equal(description, message.Description);
    }
}