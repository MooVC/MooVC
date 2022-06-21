namespace MooVC.ArrayExtensionsTests;

using System;
using Xunit;

public sealed class WhenAppendIsCalled
{
    [Fact]
    public void GivenANullArrayThenAnArrayIsReturnedWithTheElementWithin()
    {
        int[]? original = default;
        int expected = 5;

        int[] result = original.Append(expected);
        int actual = Assert.Single(result);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAnEmptyArrayThenAnArrayIsReturnedWithTheElementWithin()
    {
        int[] original = Array.Empty<int>();
        int expected = 1;

        int[] result = original.Append(expected);
        int actual = Assert.Single(result);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAnArrayThenAnArrayIsReturnedWithTheElementAtTheEnd()
    {
        int[] original = new[] { 1, 2, 3 };
        int[] expected = new[] { 1, 2, 3, 4 };
        int value = 4;

        int[] actual = original.Append(value);
        Assert.Equal(expected, actual);
    }
}