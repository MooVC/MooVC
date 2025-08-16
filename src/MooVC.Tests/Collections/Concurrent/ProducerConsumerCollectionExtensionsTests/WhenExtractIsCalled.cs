namespace MooVC.Collections.Concurrent.ProducerConsumerCollectionExtensionsTests;

using System.Collections.Concurrent;
using System.Linq;

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
        actual.ShouldBe(expected);
        source.ShouldBeEmpty();
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
        source.Intersect(actual).ShouldBeEmpty();
        source.Count.ShouldBe(Total - (int)count);
        actual.Count().ShouldBe((int)count);
    }

    [Fact]
    public void GivenANullCollectionAndACountThenAnEmptyEnumerableIsReturned()
    {
        // Arrange
        IProducerConsumerCollection<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Extract(count: 50);

        // Assert
        actual.ShouldBeEmpty();
    }

    [Fact]
    public void GivenANullCollectionThenAnEmptyEnumerableIsReturned()
    {
        // Arrange
        IProducerConsumerCollection<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Extract();

        // Assert
        actual.ShouldBeEmpty();
    }
}