namespace MooVC.Collections.Concurrent.ProducerConsumerCollectionExtensionsTests;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public sealed class WhenExtractIsCalled
{
    [Fact]
    public void GivenACollectionThenAnEnumerableContainingAllMembersIsReturnedAndTheCollectionIsEmptied()
    {
        IEnumerable<int> expected = Enumerable.Range(0, 50);

        IProducerConsumerCollection<int> source = new ConcurrentBag<int>(expected);

        IEnumerable<int> actual = source
            .Extract()
            .OrderBy(element => element);

        Assert.Equal(expected, actual);
        Assert.Empty(source);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    public void GivenACollectionAndACountThenAnEnumerableContainingTheSpecifiedNumberOfMembersIsReturned(ulong count)
    {
        const int Total = 50;

        IEnumerable<int> expected = Enumerable.Range(0, Total);

        IProducerConsumerCollection<int> source = new ConcurrentBag<int>(expected);

        IEnumerable<int> actual = source
            .Extract(count: count)
            .OrderBy(element => element);

        Assert.DoesNotContain(source, element => actual.Contains(element));
        Assert.Equal((int)(Total - count), source.Count);
        Assert.Equal((int)count, actual.Count());
    }

    [Fact]
    public void GivenANullCollectionAndACountThenAnEmptyEnumerableIsReturned()
    {
        IProducerConsumerCollection<int>? source = default;
        IEnumerable<int> actual = source.Extract(count: 50);

        Assert.Empty(actual);
    }

    [Fact]
    public void GivenANullCollectionThenAnEmptyEnumerableIsReturned()
    {
        IProducerConsumerCollection<int>? source = default;
        IEnumerable<int> actual = source.Extract();

        Assert.Empty(actual);
    }
}