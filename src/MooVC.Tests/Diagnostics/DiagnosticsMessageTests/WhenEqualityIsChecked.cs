namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using Xunit;
using Xunit.Sdk;

public sealed class WhenEqualityIsChecked
    : EqualityChecked
{
    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenTwoMessagesWithEqualContentWhenTheOperatorIsUsedThenAPositiveResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage first);
        _ = Prepare(description, arguments, out DiagnosticsMessage second);

        Assert.NotSame(first, second);
        Assert.True(first == second);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenTwoMessagesWithEqualDifferentContentWhenTheOperatorIsUsedThenANegativeResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage first);
        _ = Prepare(description, 0, out DiagnosticsMessage second);

        Assert.NotSame(first, second);
        Assert.False(first == second);
    }

    [Fact]
    public void GivenDifferingTypesWhenTheOperatorIsUsedThenANegativeResponseIsReturned()
    {
        var first = new DiagnosticsMessage("Test");
        object second = new();

        Assert.NotSame(first, second);
        Assert.False(first == second);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenTwoMessagesWithEqualContentWhenEqualsIsUsedThenAPositiveResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage first);
        _ = Prepare(description, arguments, out DiagnosticsMessage second);

        bool isEqual = first.Equals(second);

        Assert.True(isEqual);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenTwoMessagesWithDifferentContentWhenEqualsIsUsedThenANegativeResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage first);
        _ = Prepare(description, 0, out DiagnosticsMessage second);

        bool isEqual = first.Equals(second);

        Assert.False(isEqual);
    }

    [Fact]
    public void GivenDifferingTypesWhenEqualsIsUsedThenANegativeResponseIsReturned()
    {
        var first = new DiagnosticsMessage("Test");
        object second = new();

        bool isEqual = first.Equals(second);

        Assert.False(isEqual);
    }

    [Fact]
    public void GivenNullWhenEqualsIsUsedThenANegativeResponseIsReturned()
    {
        var first = new DiagnosticsMessage("Test");
        object? second = default;

        bool isEqual = first.Equals(second);

        Assert.False(isEqual);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenAStringThatMatchesTheExpectedOutputWhenTheOperatorIsUsedThenAPositiveResponseIsReturned(string description, int arguments)
    {
        string expected = Prepare(description, arguments, out DiagnosticsMessage message);

        Assert.True(expected == message);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenAStringThatDoesNotMatcheTheExpectedOutputWhenTheOperatorIsUsedThenANegativeResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage message);

        Assert.False(description == message);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenAStringThatMatchesTheExpectedOutputWhenEqualsIsUsedThenAPositiveResponseIsReturned(string description, int arguments)
    {
        string expected = Prepare(description, arguments, out DiagnosticsMessage message);
        bool isEqual = message.Equals(expected);

        Assert.True(isEqual);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenAStringThatDoesNotMatcheTheExpectedOutputWhenEqualsIsUsedThenANegativeResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage message);
        bool isEqual = message.Equals(description);

        Assert.False(isEqual);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenAStringMasqueradingAsAnObjectThatMatchesTheExpectedOutputWhenEqualsIsUsedThenAPositiveResponseIsReturned(string description, int arguments)
    {
        object expected = Prepare(description, arguments, out DiagnosticsMessage message);

        bool isEqual = message.Equals(expected);

        Assert.True(isEqual);
    }

    [Fact]
    public void GivenAStringMasqueradingAsAnObjectThatDoesNotMatchWhenEqualsIsUsedThenANegativeResponseIsReturned()
    {
        var first = new DiagnosticsMessage("Test");
        object? second = "Mismatch";

        bool isEqual = first.Equals(second);

        Assert.False(isEqual);
    }

    [Fact]
    public void GivenNullStringWhenEqualsIsUsedThenANegativeResponseIsReturned()
    {
        string? description = default;
        var message = new DiagnosticsMessage("Test");
        bool isEqual = message.Equals(description);

        Assert.False(isEqual);
    }
}