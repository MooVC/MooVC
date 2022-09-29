namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using Xunit;

public sealed class WhenInEqualityIsChecked
    : EqualityChecked
{
    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenTwoMessagesWithEqualContentThenANegativeResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage first);
        _ = Prepare(description, arguments, out DiagnosticsMessage second);

        Assert.NotSame(first, second);
        Assert.False(first != second);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenTwoMessagesWithEqualDifferentContentThenAPositiveResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage first);
        _ = Prepare(description, 0, out DiagnosticsMessage second);

        Assert.NotSame(first, second);
        Assert.True(first != second);
    }

    [Fact]
    public void GivenDifferingTypesWhenTheOperatorIsUsedThenAPositiveResponseIsReturned()
    {
        var first = new DiagnosticsMessage("Test");
        object second = new();

        Assert.NotSame(first, second);
        Assert.True(first != second);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenAStringThatMatchesTheExpectedOutputThenANegativeResponseIsReturned(string description, int arguments)
    {
        string expected = Prepare(description, arguments, out DiagnosticsMessage message);

        Assert.False(message != expected);
    }

    [Theory]
    [InlineData("Something {0}", 1)]
    [InlineData("something {0} {1}", 2)]
    [InlineData("dark  {0} {1} {2}", 3)]
    [InlineData("side. {3} ..  {0} {1} {2}", 4)]
    public void GivenAStringThatDoesNotMatcheTheExpectedOutputThenAPositiveResponseIsReturned(string description, int arguments)
    {
        _ = Prepare(description, arguments, out DiagnosticsMessage message);

        Assert.True(message != description);
    }
}