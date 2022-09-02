namespace MooVC.Collections.Generic.EnumerableExtensionsTests;

using System;
using System.Collections.Generic;
using Xunit;

public sealed class WhenToIndexIsCalled
{
    [Fact]
    public void GivenANullSelectorThenAnArgumentNullExceptionIsThrown()
    {
        Func<int, string>? selector = default;
        IEnumerable<int> source = new[] { 1, 2, 3 };

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => source.ToIndex(selector!));

        Assert.Equal(nameof(selector), exception.ParamName);
    }

    [Fact]
    public void GivenANullSourceThenAnEmptyDictionaryIsReturned()
    {
        IEnumerable<int>? source = default;

        IDictionary<int, int> index = source.ToIndex(value => value);

        Assert.NotNull(index);
        Assert.Empty(index);
    }

    [Fact]
    public void GivenANullTransformThenAnArgumentNullExceptionIsThrown()
    {
        Func<int, string>? transform = default;
        IEnumerable<int> source = new[] { 1, 2, 3 };

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => source.ToIndex(value => value, transform!));

        Assert.Equal(nameof(transform), exception.ParamName);
    }

    [Fact]
    public void GivenASourceThenAMatchingDictionaryIsReturned()
    {
        IEnumerable<int> source = new[] { 1, 2, 3 };

        IDictionary<int, int> index = source.ToIndex(value => value);

        Assert.NotNull(index);
        Assert.Equal(source, index.Keys);
        Assert.Equal(source, index.Values);
    }

    [Fact]
    public void GivenASourceAndATransformThenAMatchingDictionaryIsReturned()
    {
        IEnumerable<int> source = new[] { 1, 2, 3 };

        static string Transform(int value)
        {
            return value.ToString();
        }

        IDictionary<int, string> index = source.ToIndex(value => value, Transform);

        Assert.NotNull(index);
        Assert.Equal(source, index.Keys);
        Assert.All(index, element => Assert.Equal(Transform(element.Key), element.Value));
    }
}