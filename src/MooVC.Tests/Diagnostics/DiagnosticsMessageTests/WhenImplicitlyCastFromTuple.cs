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
    [InlineData("Hello", "something {0}")]
    [InlineData(default, "dark {0}")]
    [InlineData(5.4, "side... {0}")]
    public void GivenAStringAndAnArgumentThenAMessageIsReturnedWithTheStringSetAsTheDescriptionAndTheArgumentApplied(
        object argument,
        string description)
    {
        DiagnosticsMessage message = (description, argument);

        Assert.False(message.IsEmpty);
        object actual = Assert.Single(message.Arguments);
        Assert.Equal(description, message.Description);
        Assert.Equal(argument, actual);
    }

    [Theory]
    [InlineData(1, "Something {0}")]
    [InlineData("Hello", "something {0}")]
    [InlineData(default, "dark {0}")]
    [InlineData(5.4, "side... {0}")]
    public void GivenAStringAndTwoArgumentsThenAMessageIsReturnedWithTheStringSetAsTheDescriptionAndTheArgumentsApplied(
        object argument1,
        string description)
    {
        const int ExpectedCount = 2;

        object argument2 = new();
        DiagnosticsMessage message = (description, argument1, argument2);

        Assert.False(message.IsEmpty);
        Assert.Equal(ExpectedCount, message.Arguments.Count());
        Assert.Equal(description, message.Description);
        Assert.Equal(argument1, message.Arguments.First());
        Assert.Equal(argument2, message.Arguments.Last());
    }

    [Theory]
    [InlineData(1, "Something {0}")]
    [InlineData("Hello", "something {0}")]
    [InlineData(default, "dark {0}")]
    [InlineData(5.4, "side... {0}")]
    public void GivenAStringAndThreeArgumentsThenAMessageIsReturnedWithTheStringSetAsTheDescriptionAndTheArgumentsApplied(
        object argument2,
        string description)
    {
        const int ExpectedCount = 3;

        object argument1 = new();
        var argument3 = Guid.NewGuid();

        DiagnosticsMessage message = (description, argument1, argument2, argument3);

        Assert.False(message.IsEmpty);
        Assert.Equal(ExpectedCount, message.Arguments.Count());
        Assert.Equal(description, message.Description);
        Assert.Equal(argument1, message.Arguments.ElementAt(0));
        Assert.Equal(argument2, message.Arguments.ElementAt(1));
        Assert.Equal(argument3, message.Arguments.ElementAt(2));
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