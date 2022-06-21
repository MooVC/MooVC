namespace MooVC.ArrayExtensionsTests;

using System;
using Xunit;

public sealed class WhenPrependIsCalled
{
    [Fact]
    public void GivenANullArrayThenAnArrayIsReturnedWithTheElementWithin()
    {
        int[]? original = default;
        int expected = 5;

        int[] result = original.Prepend(expected);
        int actual = Assert.Single(result);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAnEmptyArrayThenAnArrayIsReturnedWithTheElementWithin()
    {
        int[] original = Array.Empty<int>();
        int expected = 1;

        int[] result = original.Prepend(expected);
        int actual = Assert.Single(result);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAnArrayThenAnArrayIsReturnedWithTheElementAtTheStart()
    {
        int[] original = new[] { 2, 3, 4 };
        int[] expected = new[] { 1, 2, 3, 4 };
        int value = 1;

        int[] actual = original.Prepend(value);
        Assert.Equal(expected, actual);
    }
}