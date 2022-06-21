namespace MooVC.ArrayExtensionsTests;

using System.Linq;
using Xunit;

public sealed class WhenExtendIsCalled
{
    [Fact]
    public void GivenNoInstancesAndNoSourceThenAnEmptyEnumerationIsReturned()
    {
        int[]? source = default;
        int[]? expected = default;

        int[] actual = source.Extend(expected);

        Assert.Empty(actual);
    }

    [Fact]
    public void GivenInstancesAndASourceThenTheInstancesAreCombinedWithTheSource()
    {
        const int ExpectedCount = 6;

        int[]? source = new[] { 1, 2, 3 };
        int[]? expected = new[] { 4, 5, 6 };

        int[] actual = source.Extend(expected);

        Assert.Equal(ExpectedCount, actual.Length);
        Assert.Contains(source, value => actual.Contains(value));
        Assert.Contains(expected, value => actual.Contains(value));
    }

    [Fact]
    public void GivenInstancesAndANullSourceThenTheInstancesAreCombinedWithTheSource()
    {
        int[]? source = default;
        int[]? expected = new[] { 4, 5, 6 };

        int[] actual = source.Extend(expected);

        Assert.Equal(expected, actual);
    }
}