namespace MooVC.ArrayExtensionsTests;

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

public sealed class WhenSnapshotIsCalled
{
    public static readonly IEnumerable<object[]> GivenAnArrayThenAMatchingArrayIsReturnedData = new[]
    {
        new object[] { new int[] { 1, 2 } },
        new object[] { new int[] { 1 } },
        new object[] { Array.Empty<int>() },
    };

    public static readonly IEnumerable<object[]> GivenAnArrayAndAPredicateThenAMatchingArrayIsReturnedData = new[]
    {
        new object[] { new int[] { 3, 1, 2 }, new int[] { 3, 1 } },
        new object[] { new int[] { 1, 2, 3 }, new int[] { 1, 3 } },
        new object[] { new int[] { 1 }, new int[] { 1 } },
        new object[] { Array.Empty<int>(), Array.Empty<int>() },
    };

    public static readonly IEnumerable<object?[]> GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData = new[]
    {
        new object?[] { Array.Empty<string>() },
        new object?[] { default },
    };

    [Theory]
    [MemberData(nameof(GivenAnArrayThenAMatchingArrayIsReturnedData))]
    public void GivenAnArrayThenAMatchingArrayIsReturned(int[] source)
    {
        // Act
        int[] result = source.Snapshot();

        // Assert
        _ = result.Should().Equal(source);
    }

    [Theory]
    [MemberData(nameof(GivenAnArrayAndAPredicateThenAMatchingArrayIsReturnedData))]
    public void GivenAnArrayAndAPredicateThenAMatchingArrayIsReturned(int[] original, int[] expected)
    {
        // Act
        int[] result = original.Snapshot(predicate: value => value != 2);

        // Assert
        _ = result.Should().Equal(expected);
    }

    [Theory]
    [MemberData(nameof(GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData))]
    public void GivenAnEmptyArrayThenAnEmptyArrayIsReturned(string[]? source)
    {
        // Act
        string[] result = source.Snapshot();

        // Assert
        _ = result.Should().BeEmpty();
    }

    [Theory]
    [MemberData(nameof(GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData))]
    public void GivenAnEmptyArrayAndAPredicateThenAnEmptyArrayIsReturned(string[]? source)
    {
        // Act
        string[] result = source.Snapshot(predicate: value => value != "Aarrgh!");

        // Assert
        _ = result.Should().BeEmpty();
    }
}