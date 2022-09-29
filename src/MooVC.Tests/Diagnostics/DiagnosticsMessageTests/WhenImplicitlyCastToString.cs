namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using System.Linq;
using Xunit;
using static System.String;

public sealed class WhenImplicitlyCastToString
{
    [Fact]
    public void GivenAEmptyMessageThenAnEmptyStringIsReturned()
    {
        string? description = DiagnosticsMessage.Empty;

        Assert.Empty(description);
    }

    [Theory]
    [InlineData("Something ")]
    [InlineData("something")]
    [InlineData("dark")]
    [InlineData("side...")]
    public void GivenMessageWithNoArgumentsThenTheStringMatchesTheDescription(string description)
    {
        DiagnosticsMessage message = description;
        string actual = message;

        Assert.Equal(description, actual);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenMessageWithArgumentsThenTheStringMatchesTheDescription(string description, int arguments)
    {
        object[] values = Enumerable
            .Range(1, arguments)
            .Cast<object>()
            .ToArray();

        string expected = Format(description, values);
        var message = new DiagnosticsMessage(description, values);
        string actual = message;

        Assert.Equal(expected, actual);
    }
}