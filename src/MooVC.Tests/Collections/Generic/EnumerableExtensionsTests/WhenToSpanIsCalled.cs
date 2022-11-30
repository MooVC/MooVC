namespace MooVC.Collections.Generic.EnumerableExtensionsTests;

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public sealed class WhenToSpanIsCalled
{
    [Theory]
    [InlineData(default)]
    [InlineData(new int[0])]
    public void GivenAnEmptyEnumerableThenAnEmptySpanIsReturned(IEnumerable<int>? enumerable)
    {
        ReadOnlySpan<int> actual = enumerable.ToSpan();

        Assert.True(actual.IsEmpty);
    }

    [Theory]
    [InlineData(new int[0])]
    [InlineData(new[] { 1, 2, 3 })]
    [InlineData(new[] { 2 })]
    [InlineData(new[] { 3, 2, 1 })]
    public void GivenAnEnumerableThenASpanContainingTheElementsOfTheEnumerableIsReturned(IEnumerable<int> expected)
    {
        ReadOnlySpan<int> actual = expected.ToSpan();

        for (int index = 0; index < expected.Count(); index++)
        {
            Assert.Equal(expected.ElementAt(index), actual[index]);
        }
    }
}