namespace MooVC.EnsureTests;

using System;
using Xunit;
using static System.String;
using static MooVC.Ensure;

public sealed class WhenArgumentIsAcceptableIsCalled
{
    [Fact]
    public void GivenAnInvalidArgumentWhenAMessageIsProvidedThenAnArgumentExceptionIsThrown()
    {
        const int ExpectedInvocationCount = 1;
        const string ExpectedArgumentName = "expected";
        const string ExpectedMessage = "Expected is null.";

        string argument = "A invalid value.";
        int invocationCount = 0;

        bool Predicate(string value)
        {
            invocationCount++;

            Assert.Equal(argument, value);

            return false;
        }

        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate, ExpectedMessage));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
        Assert.StartsWith(ExpectedMessage, exception.Message);
        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }

    [Fact]
    public void GivenAnInvalidArgumentWhenNoMessageIsProvidedThenAnArgumentExceptionIsThrown()
    {
        const int ExpectedInvocationCount = 1;
        const string ExpectedArgumentName = "expected";

        string argument = "A invalid value.";
        int invocationCount = 0;

        bool Predicate(string value)
        {
            invocationCount++;

            Assert.Equal(argument, value);

            return false;
        }

        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }

    [Fact]
    public void GivenANonNullNullableReferenceThenNoExceptionIsThrown()
    {
        object? expected = new();
        object actual = ArgumentIsAcceptable(expected, nameof(expected), _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANonNullNullableStructThenNoExceptionIsThrown()
    {
        TimeSpan? expected = TimeSpan.Zero;
        TimeSpan actual = ArgumentIsAcceptable(expected, nameof(expected), _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANonNullNullableValueThenNoExceptionIsThrown()
    {
        int? expected = 1;
        int actual = ArgumentIsAcceptable(expected, nameof(expected), _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANullArgumentWhenAMessageIsProvidedThenAnArgumentNullExceptionIsThrownWithoutInvokingThePredicate()
    {
        const int ExpectedInvocationCount = 0;
        const string ExpectedArgumentName = "expected";
        const string ExpectedMessage = "Expected is null.";

        string? argument = default;
        int invocationCount = 0;

        bool Predicate<T>(T value)
        {
            invocationCount++;

            return false;
        }

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate, ExpectedMessage));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
        Assert.StartsWith(ExpectedMessage, exception.Message);
        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }

    [Fact]
    public void GivenANullArgumentWhenNoMessageIsProvidedThenAnArgumentNullExceptionIsThrownWithoutInvokingThePredicate()
    {
        const int ExpectedInvocationCount = 0;
        const string ExpectedArgumentName = "expected";

        string? argument = default;
        int invocationCount = 0;

        bool Predicate<T>(T value)
        {
            invocationCount++;

            return false;
        }

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate));

        Assert.Equal(ExpectedArgumentName, exception.ParamName);
        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }

    [Fact]
    public void GivenANullNullableReferenceThenNoExceptionIsThrown()
    {
        object? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => ArgumentIsAcceptable(expected, nameof(expected), _ => true));

        Assert.Equal(nameof(expected), exception.ParamName);
    }

    [Fact]
    public void GivenANullNullableStructThenAnArgumentNullExceptionIsThrown()
    {
        TimeSpan? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => ArgumentIsAcceptable(expected, nameof(expected), _ => true));

        Assert.Equal(nameof(expected), exception.ParamName);
    }

    [Fact]
    public void GivenANullNullableValueThenAnArgumentNullExceptionIsThrown()
    {
        int? expected = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => ArgumentIsAcceptable(expected, nameof(expected), _ => true));

        Assert.Equal(nameof(expected), exception.ParamName);
    }

    [Fact]
    public void GivenAReferenceThenNoExceptionIsThrown()
    {
        object expected = new();
        object actual = ArgumentIsAcceptable(expected, nameof(expected), _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAStructWhenThePredicateFailsThenAnArgumentExceptionIsThrown()
    {
        TimeSpan expected = TimeSpan.Zero;

        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            ArgumentIsAcceptable<TimeSpan>(expected, nameof(expected), _ => false));

        Assert.Equal(nameof(expected), exception.ParamName);
    }

    [Fact]
    public void GivenAValueWhenThePredicateFailsThenAnArgumentExceptionIsThrown()
    {
        int expected = 1;

        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            ArgumentIsAcceptable<int>(expected, nameof(expected), _ => false));

        Assert.Equal(nameof(expected), exception.ParamName);
    }

    [Fact]
    public void GivenAStructAndAMessageWhenThePredicateFailsThenAnArgumentExceptionIsThrown()
    {
        const string Message = "Something something dark side...";
        TimeSpan expected = TimeSpan.Zero;

        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            ArgumentIsAcceptable<TimeSpan>(expected, nameof(expected), _ => false, Message));

        Assert.Equal(nameof(expected), exception.ParamName);
        Assert.StartsWith(Message, exception.Message);
    }

    [Fact]
    public void GivenAValueAndAMessageWhenThePredicateFailsThenAnArgumentExceptionIsThrown()
    {
        const string Message = "Something something dark side...";
        int expected = 1;

        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            ArgumentIsAcceptable<int>(expected, nameof(expected), _ => false, Message));

        Assert.Equal(nameof(expected), exception.ParamName);
        Assert.StartsWith(Message, exception.Message);
    }

    [Fact]
    public void GivenAStructThenNoExceptionIsThrown()
    {
        TimeSpan expected = TimeSpan.Zero;
        TimeSpan actual = ArgumentIsAcceptable<TimeSpan>(expected, nameof(expected), _ => true);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAValueThenNoExceptionIsThrown()
    {
        int expected = 1;
        int actual = ArgumentIsAcceptable<int>(expected, nameof(expected), _ => true);

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

        string result = ArgumentIsAcceptable(argument, Empty, Predicate, Empty);

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

        string result = ArgumentIsAcceptable(argument, Empty, Predicate);

        Assert.Same(argument, result);
        Assert.Equal(ExpectedInvocationCount, invocationCount);
    }
}