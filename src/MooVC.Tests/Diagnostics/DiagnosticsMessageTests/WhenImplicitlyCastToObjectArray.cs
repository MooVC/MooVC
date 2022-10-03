namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using System.Linq;
using Xunit;
using static System.String;

public sealed class WhenImplicitlyCastToObjectArray
{
    [Fact]
    public void GivenAEmptyMessageThenAnEmptyArrayIsReturned()
    {
        object[] arguments = DiagnosticsMessage.Empty;

        Assert.NotNull(arguments);
        Assert.Empty(arguments);
    }

    [Theory]
    [InlineData("Something ")]
    [InlineData("something")]
    [InlineData("dark")]
    [InlineData("side...")]
    public void GivenMessageWithNoArgumentsThenAnEmptyArrayIsReturned(string description)
    {
        DiagnosticsMessage message = description;
        object[] actual = message;

        Assert.NotNull(actual);
        Assert.Empty(actual);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenMessageWithArgumentsThenTheArgumentsAreReturned(string description, int arguments)
    {
        object[] expected = Enumerable
            .Range(1, arguments)
            .Cast<object>()
            .ToArray();

        var message = new DiagnosticsMessage(description, expected);
        object[] actual = message;

        Assert.Equal(expected, actual);
    }
}