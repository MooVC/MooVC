namespace MooVC.EnsureTests;

using System;
using System.Collections.Generic;
using Xunit;
using static MooVC.Ensure;

public sealed class WhenIsNotNullIsCalled
{
    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANonNullReferenceThenTheReferenceIsReturned(string? argumentName, string? message)
    {
        object? expected = new();
        object actual = Assertion(expected, argumentName, message);

        Assert.Same(expected, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullReferenceWhenADefaultIsProvidedThenTheDefaultIsReturned(string? argumentName, string? message)
    {
        object @default = new();
        object? value = default;
        object actual = Assertion(value, argumentName, message, @default: @default);

        Assert.Same(@default, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullReferenceTheAnArgumentNullExceptionIsThrown(string? argumentName, string? message)
    {
        object? value = default;

        _ = AssertThrows(value, argumentName, message);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANonNullStructThenTheStructIsReturned(string? argumentName, string? message)
    {
        TimeSpan? expected = TimeSpan.MaxValue;
        TimeSpan actual = Assertion(expected, argumentName, message);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullStructWhenADefaultIsProvidedThenTheDefaultIsReturned(string? argumentName, string? message)
    {
        var @default = TimeSpan.FromSeconds(4);
        TimeSpan? value = default;
        object actual = Assertion(value, argumentName, message, @default: @default);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullStructTheAnArgumentNullExceptionIsThrown(string? argumentName, string? message)
    {
        TimeSpan? value = default;

        _ = AssertThrows(value, argumentName, message);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANonNullValueThenTheValueIsReturned(string? argumentName, string? message)
    {
        int? expected = int.MaxValue;
        int actual = Assertion(expected, argumentName, message);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullValueWhenADefaultIsProvidedThenTheDefaultIsReturned(string? argumentName, string? message)
    {
        int @default = 6;
        int? value = default;
        object actual = Assertion(value, argumentName, message, @default: @default);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullValueTheAnArgumentNullExceptionIsThrown(string? argumentName, string? message)
    {
        int? value = default;

        _ = AssertThrows(value, argumentName, message);
    }

    private static T Assertion<T>(T? argument, string? argumentName, string? message, T? @default = default)
        where T : struct
    {
        if (argumentName is { })
        {
            return IsNotNull(argument, argumentName: argumentName, @default: @default, message: message);
        }

        return IsNotNull(argument, @default: @default, message: message);
    }

    private static ArgumentNullException AssertThrows<T>(T? argument, string? argumentName, string? message)
        where T : struct
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            Assertion(argument, argumentName, message));

        argumentName ??= nameof(argument);

        Assert.Equal(argumentName, exception.ParamName);

        if (message is { })
        {
            Assert.StartsWith(message, exception.Message);
        }

        return exception;
    }

    private static T Assertion<T>(T? argument, string? argumentName, string? message, T? @default = default)
        where T : class
    {
        if (argumentName is { })
        {
            return IsNotNull(argument, argumentName: argumentName, @default: @default, message: message);
        }

        return IsNotNull(argument, @default: @default, message: message);
    }

    private static ArgumentNullException AssertThrows<T>(T? argument, string? argumentName, string? message)
        where T : class
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            Assertion(argument, argumentName, message));

        argumentName ??= nameof(argument);

        Assert.Equal(argumentName, exception.ParamName);

        if (message is { })
        {
            Assert.StartsWith(message, exception.Message);
        }

        return exception;
    }
}