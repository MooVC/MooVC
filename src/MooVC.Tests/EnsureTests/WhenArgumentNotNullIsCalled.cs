namespace MooVC.EnsureTests;

using System;
using Xunit;
using static MooVC.Ensure;

public sealed class WhenArgumentNotNullIsCalled
{
    [Fact]
    public void GivenANonNullNullableReferenceThenNoExceptionIsThrown()
    {
        object? expected = new();
        object actual = ArgumentNotNull(expected, nameof(expected));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANonNullNullableStructThenNoExceptionIsThrown()
    {
        TimeSpan? expected = TimeSpan.Zero;
        TimeSpan actual = ArgumentNotNull(expected, nameof(expected));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANonNullNullableValueThenNoExceptionIsThrown()
    {
        int? expected = 1;
        int actual = ArgumentNotNull(expected, nameof(expected));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(-1)]
    [InlineData(1.0)]
    [InlineData(-1.0)]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenANonNullValueAndAMessageThenNoExceptionIsThrown(object argument)
    {
        object result = ArgumentNotNull(
            argument,
            nameof(argument),
            "Some message.");

        Assert.Same(argument, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(-1)]
    [InlineData(1.0)]
    [InlineData(-1.0)]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenANonNullValueThenNoExceptionIsThrown(object argument)
    {
        object result = ArgumentNotNull(argument, nameof(argument));

        Assert.Same(argument, result);
    }

    [Fact]
    public void GivenANullArgumentThenAnArgumentNullExceptionIsThrown()
    {
        const string ExpectedArgumentName = "expected";

        string? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ArgumentNotNull(value, ExpectedArgumentName));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
    }

    [Fact]
    public void GivenANullArgumentThenAnArgumentNullExceptionIsThrownWithTheMessageAttached()
    {
        const string ExpectedArgumentName = "expected";
        const string ExpectedMessage = "Expected is null.";

        string? value = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ArgumentNotNull(value, ExpectedArgumentName, ExpectedMessage));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
        Assert.StartsWith(ExpectedMessage, exception.Message);
    }

    [Fact]
    public void GivenANullNullableReferenceThenNoExceptionIsThrown()
    {
        object? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => ArgumentNotNull(expected, nameof(expected)));

        Assert.Equal(nameof(expected), exception.ParamName);
    }

    [Fact]
    public void GivenANullNullableStructThenAnArgumentNullExceptionIsThrown()
    {
        TimeSpan? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => ArgumentNotNull(expected, nameof(expected)));

        Assert.Equal(nameof(expected), exception.ParamName);
    }

    [Fact]
    public void GivenANullNullableValueThenAnArgumentNullExceptionIsThrown()
    {
        int? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => ArgumentNotNull(expected, nameof(expected)));

        Assert.Equal(nameof(expected), exception.ParamName);
    }

    [Fact]
    public void GivenANullNullableReferenceThenAnArgumentNullExceptionIsThrownWithTheMessageAttached()
    {
        const string ExpectedArgumentName = "expected";
        const string ExpectedMessage = "Expected is null.";

        object? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ArgumentNotNull(expected, ExpectedArgumentName, ExpectedMessage));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
        Assert.StartsWith(ExpectedMessage, exception.Message);
    }

    [Fact]
    public void GivenANullNullableStructThenAnArgumentNullExceptionIsThrownWithTheMessageAttached()
    {
        const string ExpectedArgumentName = "expected";
        const string ExpectedMessage = "Expected is null.";

        TimeSpan? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ArgumentNotNull(expected, ExpectedArgumentName, ExpectedMessage));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
        Assert.StartsWith(ExpectedMessage, exception.Message);
    }

    [Fact]
    public void GivenANullNullableValueThenAnArgumentNullExceptionIsThrownWithTheMessageAttached()
    {
        const string ExpectedArgumentName = "expected";
        const string ExpectedMessage = "Expected is null.";

        int? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ArgumentNotNull(expected, ExpectedArgumentName, ExpectedMessage));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
        Assert.StartsWith(ExpectedMessage, exception.Message);
    }
}