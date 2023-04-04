namespace MooVC.ArrayExtensionsTests;

using System;
using System.Collections.Generic;
using System.Linq;
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

    [Theory]
    [MemberData(nameof(GivenAnArrayThenAMatchingArrayIsReturnedData))]
    public void GivenAnArrayThenAMatchingArrayIsReturned(int[] source)
    {
        int[] result = source.Snapshot();

        Assert.Equal(source, result);
    }

    [Theory]
    [MemberData(nameof(GivenAnArrayAndAPredicateThenAMatchingArrayIsReturnedData))]
    public void GivenAnArrayAndAPredicateThenAMatchingArrayIsReturned(
        int[] original,
        int[] expected)
    {
        int[] result = original.Snapshot(predicate: value => value != 2);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new string[0])]
    [InlineData(default)]
    public void GivenAnEmptyArrayThenAnEmptyArrayIsReturned(string[]? source)
    {
        string[] result = source.Snapshot();

        Assert.Empty(result);
    }

    [Theory]
    [InlineData(new string[0])]
    [InlineData(default)]
    public void GivenAnEmptyArrayAndAPredicateThenAnEmptyArrayIsReturned(string[]? source)
    {
        string[] result = source.Snapshot(predicate: value => value != 2);

        Assert.Empty(result);
    }
}