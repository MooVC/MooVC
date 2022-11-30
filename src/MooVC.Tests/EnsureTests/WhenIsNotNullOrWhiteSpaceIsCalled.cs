namespace MooVC.EnsureTests;

using System;
using Xunit;

public sealed class WhenIsNotNullOrWhiteSpaceIsCalled
{
    [Fact]
    public void GivenANonNullValueThenNoExceptionIsThrown()
    {
        const string Argument = "Some Value";
        const string Message = "Some Message";

        string result = Ensure.IsNotNullOrWhiteSpace(Argument, message: Message);

        Assert.Same(Argument, result);
    }

    [Theory]
    [InlineData(null, "Something")]
    [InlineData("", "Dark")]
    [InlineData(" ", "Side")]
    public void GivenANullArgumentAndADefaultTheTheDefaultIsReturned(string argument, string @default)
    {
        const string Message = "Some Message";

        string value = Ensure.IsNotNullOrWhiteSpace(argument, @default: @default, message: Message);

        Assert.Equal(@default, value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenANullArgumentThenAnArgumentNullExceptionIsThrown(string argument)
    {
        const string Message = "Some Message";

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            Ensure.IsNotNullOrWhiteSpace(argument, message: Message));

        Assert.Equal(nameof(argument), exception.ParamName);
    }

    [Theory]
    [InlineData(null, "Something")]
    [InlineData("", "Dark")]
    [InlineData(" ", "Side")]
    public void GivenANullArgumentAndAnArgumentNameThenAnArgumentNullExceptionIsThrownWithThatArgumentName(string argument, string argumentName)
    {
        const string Message = "Some Message";

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            Ensure.IsNotNullOrWhiteSpace(argument, argumentName: argumentName, message: Message));

        Assert.Equal(argumentName, exception.ParamName);
    }
}