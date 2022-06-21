namespace MooVC.Collections.Generic.EnumerableExtensionsTests;

using System.Collections.Generic;
using System.Linq;
using Xunit;

public sealed class WhenCombineIsCalled
{
    [Fact]
    public void GivenAnInstanceAndASourceThenTheInstanceIsCombinedWithTheSource()
    {
        const int ExpectedValue = 9;
        const int ExpectedCount = 4;

        int[] source = new[] { 1, 2, 3 };
        IEnumerable<int> actual = source.Combine(ExpectedValue);

        Assert.Equal(ExpectedCount, actual.Count());
        Assert.Contains(ExpectedValue, actual);
    }

    [Fact]
    public void GivenAnInstanceAndANullSourceThenTheInstanceIsCombinedWithTheSource()
    {
        const int ExpectedValue = 9;

        IEnumerable<int>? source = default;
        IEnumerable<int> actual = source.Combine(ExpectedValue);

        int actualValue = Assert.Single(actual);
        Assert.Equal(ExpectedValue, actualValue);
    }

    [Fact]
    public void GivenNoInstancesAndNoSourceThenAnEmptyEnumerationIsReturned()
    {
        IEnumerable<int>? source = default;
        IEnumerable<int>? expected = default;

        IEnumerable<int> actual = source.Combine(expected);

        Assert.Empty(actual);
    }

    [Fact]
    public void GivenInstancesAndASourceThenTheInstancesAreCombinedWithTheSource()
    {
        const int ExpectedCount = 6;

        IEnumerable<int>? source = new[] { 1, 2, 3 };
        IEnumerable<int>? expected = new[] { 4, 5, 6 };

        IEnumerable<int> actual = source.Combine(expected);

        Assert.Equal(ExpectedCount, actual.Count());
        Assert.Contains(source, value => actual.Contains(value));
        Assert.Contains(expected, value => actual.Contains(value));
    }

    [Fact]
    public void GivenInstancesAndANullSourceThenTheInstancesAreCombinedWithTheSource()
    {
        IEnumerable<int>? source = default;
        IEnumerable<int>? expected = new[] { 4, 5, 6 };

        IEnumerable<int> actual = source.Combine(expected);

        Assert.Equal(expected, actual);
    }
}