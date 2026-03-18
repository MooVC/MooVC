namespace MooVC.Collections.Concurrent.ProducerConsumerCollectionExtensionsTests;

using System.Collections.Concurrent;
using System.Linq;

public sealed class WhenExtractIsCalled
{
    [Test]
    public async Task GivenACollectionThenAnEnumerableContainingAllMembersIsReturnedAndTheCollectionIsEmptied()
    {
        // Arrange
        IEnumerable<int> expected = Enumerable.Range(0, 50);
        IProducerConsumerCollection<int> source = new ConcurrentBag<int>(expected);

        // Act
        IEnumerable<int> actual = source
            .Extract()
            .OrderBy(element => element);

        // Assert
        await Assert.That(actual).IsEqualTo(expected);
        await Assert.That(source).IsEmpty();
    }

    [Test]
    [Arguments(1)]
    [Arguments(10)]
    [Arguments(25)]
    [Arguments(50)]
    public async Task GivenACollectionAndACountThenAnEnumerableContainingTheSpecifiedNumberOfMembersIsReturned(ulong count)
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
        await Assert.That(source.Intersect(actual)).IsEmpty();
        await Assert.That(source.Count).IsEqualTo(Total - (int)count);
        await Assert.That(actual.Count()).IsEqualTo((int)count);
    }

    [Test]
    public async Task GivenANullCollectionAndACountThenAnEmptyEnumerableIsReturned()
    {
        // Arrange
        IProducerConsumerCollection<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Extract(count: 50);

        // Assert
        await Assert.That(actual).IsEmpty();
    }

    [Test]
    public async Task GivenANullCollectionThenAnEmptyEnumerableIsReturned()
    {
        // Arrange
        IProducerConsumerCollection<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Extract();

        // Assert
        await Assert.That(actual).IsEmpty();
    }
}