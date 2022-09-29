namespace MooVC.EnsureTests;

using System;
using Xunit;
using static MooVC.Ensure;

public sealed class WhenIsDefinedIsCalled
{
    [Flags]
    public enum Test
    {
        First = 1,
        Second = 4,
        Third = 8,
    }

    [Theory]
    [InlineData(default, default, Test.Second)]
    [InlineData(default, "Expected Message", Test.First)]
    [InlineData("Expected Name", default, Test.Third)]
    [InlineData("The Name", "The Message", Test.Second)]
    public void GivenAnExistingValueThenTheValueIsReturned(string? argumentName, string? message, Test value)
    {
        Test actual = Assertion(value, argumentName: argumentName, message: message);

        Assert.Equal(value, actual);
    }

    [Theory]
    [InlineData(default, Test.Second, default, default)]
    [InlineData(default, Test.First, "Expected Message", (Test)9)]
    [InlineData("Expected Name", Test.Third, default, (Test)0)]
    [InlineData("The Name", (Test)7, "The Message", (Test)(-27))]
    public void GivenANonExistingValueAndADefaultThenTheDefaultValueIsReturned(string? argumentName, Test @default, string? message, Test? value)
    {
        Test actual = Assertion(value, argumentName: argumentName, @default: @default, message: message);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData(default, default, default)]
    [InlineData(default, "Expected Message", (Test)9)]
    [InlineData("Expected Name", default, (Test)0)]
    [InlineData("The Name", "The Message", (Test)(-27))]
    public void GivenANonExistingValueAndNoDefaultThenAnArgumentExceptionIsThrown(string? argumentName, string? message, Test? value)
    {
        _ = AssertThrows(value, argumentName: argumentName, message: message);
    }

    private static Test Assertion(Test? argument, string? argumentName, string? message, Test? @default = default)
    {
        if (argumentName is { })
        {
            return IsDefined(argument, argumentName: argumentName, @default: @default, message: message);
        }

        return IsDefined(argument, @default: @default, message: message);
    }

    private static ArgumentException AssertThrows(Test? argument, string? argumentName, string? message)
    {
        ArgumentException exception = Assert.ThrowsAny<ArgumentException>(() =>
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