namespace MooVC.EnsureTests;

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static MooVC.Ensure;

public sealed class WhenIsNotEmptyIsCalled
{
    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenAnEmptyGuidThenAnArgumentExceptionIsThrown(string? argumentName, string? message)
    {
        Guid expected = Guid.Empty;

        void Assertion()
        {
            if (argumentName is { })
            {
                _ = IsNotEmpty(expected, argumentName: argumentName, message: message);
            }

            _ = IsNotEmpty(expected, message: message);
        }

        ArgumentException exception = Assert.Throws<ArgumentException>(Assertion);

        argumentName ??= nameof(expected);

        Assert.Equal(argumentName, exception.ParamName);

        if (message is { })
        {
            Assert.StartsWith(message, exception.Message);
        }
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenAnEmptyTimeSpanThenAnArgumentExceptionIsThrown(string? argumentName, string? message)
    {
        TimeSpan expected = TimeSpan.Zero;

        void Assertion()
        {
            if (argumentName is { })
            {
                _ = IsNotEmpty(expected, argumentName: argumentName, message: message);
            }

            _ = IsNotEmpty(expected, message: message);
        }

        ArgumentException exception = Assert.Throws<ArgumentException>(Assertion);

        argumentName ??= nameof(expected);

        Assert.Equal(argumentName, exception.ParamName);

        if (message is { })
        {
            Assert.StartsWith(message, exception.Message);
        }
    }

    [Theory]
    [InlineData(default, default, default)]
    [InlineData(default, default, "Expected Message")]
    [InlineData("Expected Name", default, default)]
    [InlineData("The Name", default, "The Message")]
    [InlineData(default, new int[0], default)]
    [InlineData(default, new int[0], "Expected Message")]
    [InlineData("Expected Name", new int[0], default)]
    [InlineData("The Name", new int[0], "The Message")]
    public void GivenAnEmptyEnumerationThenAnArgumentExceptionIsThrown(string? argumentName, IEnumerable<int>? enumeration, string? message)
    {
        AssertArgumentExceptionIsThrownForEnumeration(argumentName, enumeration, message);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenAnEnumerationWithAMessageAndANegativePredicateThenAnArgumentExceptionIsThrown(string? argumentName, string? message)
    {
        IEnumerable<int> enumeration = Enumerable.Range(1, 5);

        AssertArgumentExceptionIsThrownForEnumeration(argumentName, enumeration, message, predicate: _ => false);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenAnEnumerationWithNoPredicateThenASnapshotIsReturned(string? argumentName, string? message)
    {
        IEnumerable<int> enumeration = Enumerable.Range(1, 5);

        int[] snapshot = AssertEnumeration(argumentName, enumeration, message);

        Assert.Equal(enumeration, snapshot);
    }

    [Theory]
    [InlineData(default, default)]
    [InlineData(default, "Expected Message")]
    [InlineData("Expected Name", default)]
    [InlineData("The Name", "The Message")]
    public void GivenAnEnumerationWithAPositivePredicateThenASnapshotIsReturned(string? argumentName, string? message)
    {
        IEnumerable<int> enumeration = Enumerable.Range(1, 5);

        int[] snapshot = AssertEnumeration(argumentName, enumeration, message, predicate: _ => true);

        Assert.Equal(enumeration, snapshot);
    }

    [Theory]
    [InlineData(default, default, new int[0], default)]
    [InlineData(default, default, new int[0], "Expected Message")]
    [InlineData("Expected Name", default, new int[0], default)]
    [InlineData("The Name", default, new int[0], "The Message")]
    [InlineData(default, default, new[] { 1, 2, 3 }, default)]
    [InlineData(default, default, new[] { 1, 2, 3 }, "Expected Message")]
    [InlineData("Expected Name", default, new[] { 1, 2, 3 }, default)]
    [InlineData("The Name", default, new[] { 1, 2, 3 }, "The Message")]
    [InlineData(default, new int[0], new int[0], default)]
    [InlineData(default, new int[0], new int[0], "Expected Message")]
    [InlineData("Expected Name", new int[0], new int[0], default)]
    [InlineData("The Name", new int[0], new int[0], "The Message")]
    [InlineData(default, new int[0], new[] { 1, 2, 3 }, default)]
    [InlineData(default, new int[0], new[] { 1, 2, 3 }, "Expected Message")]
    [InlineData("Expected Name", new int[0], new[] { 1, 2, 3 }, default)]
    [InlineData("The Name", new int[0], new[] { 1, 2, 3 }, "The Message")]
    public void GivenAnEmptyEnumerationAndADefaultThenASnapshotOfTheDefaultIsReturned(
        string? argumentName,
        IEnumerable<int>? enumeration,
        IEnumerable<int> @default,
        string? message)
    {
        int[] snapshot = AssertEnumeration(argumentName, enumeration, message, @default: @default);

        Assert.Equal(@default, snapshot);
    }

    [Theory]
    [InlineData(default, new int[0], default)]
    [InlineData(default, new int[0], "Expected Message")]
    [InlineData("Expected Name", new int[0], default)]
    [InlineData("The Name", new int[0], "The Message")]
    [InlineData(default, new[] { 1, 2, 3 }, default)]
    [InlineData(default, new[] { 1, 2, 3 }, "Expected Message")]
    [InlineData("Expected Name", new[] { 1, 2, 3 }, default)]
    [InlineData("The Name", new[] { 1, 2, 3 }, "The Message")]
    public void GivenAnEnumerationAndADefaultWhenThePredicateFailsThenASnapshotOfTheDefaultIsReturned(
        string? argumentName,
        IEnumerable<int> @default,
        string? message)
    {
        IEnumerable<int> enumeration = Enumerable.Range(1, 5);

        int[] snapshot = AssertEnumeration(argumentName, enumeration, message, @default: @default, predicate: _ => false);

        Assert.Equal(@default, snapshot);
    }

    private static int[] AssertEnumeration(
        string? argumentName,
        IEnumerable<int>? enumeration,
        string? message,
        IEnumerable<int>? @default = default,
        Func<int, bool>? predicate = default)
    {
        if (argumentName is { })
        {
            return IsNotEmpty(enumeration, argumentName: argumentName, @default: @default, message: message, predicate: predicate);
        }

        return IsNotEmpty(enumeration, @default: @default, message: message, predicate: predicate);
    }

    private static void AssertArgumentExceptionIsThrownForEnumeration(
        string? argumentName,
        IEnumerable<int>? enumeration,
        string? message,
        Func<int, bool>? predicate = default)
    {
        ArgumentException exception = Assert.ThrowsAny<ArgumentException>(() =>
            AssertEnumeration(argumentName, enumeration, message, predicate: predicate));

        argumentName ??= nameof(enumeration);

        Assert.Equal(argumentName, exception.ParamName);

        if (message is { })
        {
            Assert.StartsWith(message, exception.Message);
        }
    }
}