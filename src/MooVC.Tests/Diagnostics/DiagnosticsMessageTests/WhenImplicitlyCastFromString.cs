namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using Xunit;

public sealed class WhenImplicitlyCastFromString
{
    [Theory]
    [InlineData(default)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenAEmptyStringThenTheEmptyInstanceIsReturned(string? description)
    {
        DiagnosticsMessage message = description;

        Assert.True(message.IsEmpty);
        Assert.Same(DiagnosticsMessage.Empty, message);
    }

    [Theory]
    [InlineData("Something")]
    [InlineData("something")]
    [InlineData("dark")]
    [InlineData("side...")]
    public void GivenAStringThenAMessageIsReturnedWithTheStringSetAsTheDescription(string? description)
    {
        DiagnosticsMessage message = description;

        Assert.False(message.IsEmpty);
        Assert.Equal(description, message.Description);
    }
}