namespace MooVC.EnsureTests;

using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit;
using static System.String;
using static MooVC.Ensure;

public sealed class WhenSatisfiesIsCalled
{
    [Fact]
    public void GivenAnNullReferenceWhenADefaultIsProvidedThenTheDefaultIsReturnedWithoutInvokingThePredicate()
    {
        object? argument = default;
        object @default = new();
        bool wasInvoked = false;

        bool Predicate(object value)
        {
            return wasInvoked = true;
        }

        object actual = Satisfies(argument, Predicate, @default: @default);

        Assert.Same(@default, actual);
        Assert.False(wasInvoked);
    }

    [Fact]
    public void GivenAnNullStructWhenADefaultIsProvidedThenTheDefaultIsReturnedWithoutInvokingThePredicate()
    {
        TimeSpan? argument = default;
        TimeSpan @default = TimeSpan.MaxValue;
        bool wasInvoked = false;

        bool Predicate(TimeSpan value)
        {
            return wasInvoked = true;
        }

        TimeSpan actual = Satisfies(argument, Predicate, @default: @default);

        Assert.Equal(@default, actual);
        Assert.False(wasInvoked);
    }

    [Fact]
    public void GivenAnNullValueWhenADefaultIsProvidedThenTheDefaultIsReturnedWithoutInvokingThePredicate()
    {
        int? argument = default;
        int @default = int.MinValue;
        bool wasInvoked = false;

        bool Predicate(int value)
        {
            return wasInvoked = true;
        }

        int actual = Satisfies(argument, Predicate, @default: @default);

        Assert.Equal(@default, actual);
        Assert.False(wasInvoked);
    }

    [Fact]
    public void GivenAnReferenceAndADefaultWhenThePredicateFailsThenTheDefaultIsReturned()
    {
        object argument = new();
        object @default = new();

        object actual = Satisfies(argument, _ => false, @default: @default);

        Assert.Same(@default, actual);
    }

    [Fact]
    public void GivenAStructAndADefaultWhenThePredicateFailsThenTheDefaultIsReturned()
    {
        var argument = TimeSpan.FromSeconds(9);
        var @default = TimeSpan.FromSeconds(21);

        TimeSpan actual = Satisfies<TimeSpan>(argument, _ => false, @default: @default);

        Assert.Equal(@default, actual);
    }

    [Fact]
    public void GivenAValueAndADefaultWhenThePredicateFailsThenTheDefaultIsReturned()
    {
        int argument = 9;
        int @default = 21;

        int actual = Satisfies<int>(argument, _ => false, @default: @default);

        Assert.Equal(@default, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenAnInvalidArgumentThenAnArgumentExceptionIsThrown(string? argumentName, string? message)
    {
        const int ExpectedInvocationCount = 1;

        string argument = "A invalid value.";
        int invocationCount = 0;

        bool Predicate(string value)
        {
            invocationCount++;

            Assert.Equal(argument, value);

            return false;
        }

        _ = AssertThrows<string, ArgumentException>(argument, argumentName, message, predicate: Predicate);

        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }

    [Fact]
    public void GivenANonNullNullableReferenceThenNoExceptionIsThrown()
    {
        object? expected = new();
        object actual = Satisfies(expected, _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANonNullNullableStructThenNoExceptionIsThrown()
    {
        TimeSpan? expected = TimeSpan.Zero;
        TimeSpan actual = Satisfies(expected, _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANonNullNullableValueThenNoExceptionIsThrown()
    {
        int? expected = 1;
        int actual = Satisfies(expected, _ => true);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullArgumentThenAnArgumentNullExceptionIsThrownWithoutInvokingThePredicate(string? argumentName, string? message)
    {
        const int ExpectedInvocationCount = 0;

        string? argument = default;
        int invocationCount = 0;

        bool Predicate<T>(T value)
        {
            invocationCount++;

            return false;
        }

        _ = AssertThrows<object, ArgumentNullException>(argument, argumentName, message, predicate: Predicate);

        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullNullableReferenceThenAnArgumentNullExceptionIsThrown(string? argumentName, string? message)
    {
        object? argument = default;

        _ = AssertThrows<object, ArgumentNullException>(argument, argumentName, message);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullNullableStructThenAnArgumentNullExceptionIsThrown(string? argumentName, string? message)
    {
        TimeSpan? argument = default;

        _ = AssertThrows<TimeSpan, ArgumentNullException>(argument, argumentName, message);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenANullNullableValueThenAnArgumentNullExceptionIsThrown(string? argumentName, string? message)
    {
        int? argument = default;

        _ = AssertThrows<int, ArgumentNullException>(argument, argumentName, message);
    }

    [Fact]
    public void GivenAReferenceThenNoExceptionIsThrown()
    {
        object expected = new();
        object actual = Satisfies(expected, _ => true);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenAStructWhenThePredicateFailsThenAnArgumentExceptionIsThrown(string? argumentName, string? message)
    {
        TimeSpan expected = TimeSpan.Zero;

        _ = AssertThrows<TimeSpan, ArgumentException>(expected, argumentName, message, predicate: _ => false);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenAValueWhenThePredicateFailsThenAnArgumentExceptionIsThrown(string? argumentName, string? message)
    {
        int expected = 1;

        _ = AssertThrows<int, ArgumentException>(expected, argumentName, message, predicate: _ => false);
    }

    [Fact]
    public void GivenAStructThenNoExceptionIsThrown()
    {
        TimeSpan expected = TimeSpan.Zero;
        TimeSpan actual = Satisfies<TimeSpan>(expected, _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAValueThenNoExceptionIsThrown()
    {
        int expected = 1;
        int actual = Satisfies<int>(expected, _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAValidArgumentWhenAMessageIsProvidedThenNoExceptionIsThrown()
    {
        const int ExpectedInvocationCount = 1;

        string argument = "A valid value.";
        int invocationCount = 0;

        bool Predicate(string value)
        {
            invocationCount++;

            Assert.Equal(argument, value);

            return true;
        }

        string result = Satisfies(argument, Predicate, message: Empty);

        Assert.Same(argument, result);
        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }

    [Fact]
    public void GivenAValidArgumentWhenNoMessageIsProvidedThenNoExceptionIsThrown()
    {
        const int ExpectedInvocationCount = 1;

        string argument = "A valid value.";
        int invocationCount = 0;

        bool Predicate(string value)
        {
            invocationCount++;

            Assert.Equal(argument, value);

            return true;
        }

        string result = Satisfies(argument, Predicate);

        Assert.Same(argument, result);
        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }

    private static TException AssertThrows<T, TException>(T? argument, string? argumentName, string? message, Func<T, bool>? predicate = default)
        where T : struct
        where TException : ArgumentException
    {
        predicate ??= _ => true;

        void Assertion()
        {
            if (argumentName is null)
            {
                _ = Satisfies(argument, predicate, message: message);
            }

            _ = Satisfies(argument, predicate, argumentName: argumentName, message: message);
        }

        TException exception = Assert.Throws<TException>(Assertion);

        argumentName ??= nameof(argument);

        Assert.Equal(argumentName, exception.ParamName);

        if (message is { })
        {
            Assert.StartsWith(message, exception.Message);
        }

        return exception;
    }

    private static TException AssertThrows<T, TException>(T? argument, string? argumentName, string? message, Func<T, bool>? predicate = default)
        where T : class
        where TException : ArgumentException
    {
        predicate ??= _ => true;

        void Assertion()
        {
            if (argumentName is null)
            {
                _ = Satisfies(argument, predicate, message: message);
            }

            _ = Satisfies(argument, predicate, argumentName: argumentName, message: message);
        }

        TException exception = Assert.Throws<TException>(Assertion);

        argumentName ??= nameof(argument);

        Assert.Equal(argumentName, exception.ParamName);

        if (message is { })
        {
            Assert.StartsWith(message, exception.Message);
        }

        return exception;
    }
}