namespace MooVC.Collections.Concurrent.ProducerConsumerCollectionExtensionsTests;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

public sealed class WhenExtractIsCalled
{
    [Fact]
    public void GivenACollectionThenAnEnumerableContainingAllMembersIsReturnedAndTheCollectionIsEmptied()
    {
        // Arrange
        IEnumerable<int> expected = Enumerable.Range(0, 50);
        IProducerConsumerCollection<int> source = new ConcurrentBag<int>(expected);

        // Act
        IEnumerable<int> actual = source
            .Extract()
            .OrderBy(element => element);

        // Assert
        _ = actual.Should().Equal(expected);
        _ = source.Should().BeEmpty();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    public void GivenACollectionAndACountThenAnEnumerableContainingTheSpecifiedNumberOfMembersIsReturned(ulong count)
    {
        // Arrange
        const int Total = 50;
        IEnumerable<int> expected = Enumerable.Range(0, Total);
        IProducerConsumerCollection<int> source = new ConcurrentBag<int>(expected);

        // Act
        IEnumerable<int> actual = source
            .Extract(count: count)
            .OrderBy(element => element);

        // Assert
        _ = source.Should().NotContain(actual);
        _ = source.Count.Should().Be(Total - (int)count);
        _ = actual.Count().Should().Be((int)count);
    }

    [Fact]
    public void GivenANullCollectionAndACountThenAnEmptyEnumerableIsReturned()
    {
        // Arrange
        IProducerConsumerCollection<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Extract(count: 50);

        // Assert
        _ = actual.Should().BeEmpty();
    }

    [Fact]
    public void GivenANullCollectionThenAnEmptyEnumerableIsReturned()
    {
        // Arrange
        IProducerConsumerCollection<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Extract();

        // Assert
        _ = actual.Should().BeEmpty();
    }
}