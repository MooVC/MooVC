namespace MooVC.Collections.Concurrent.ProducerConsumerCollectionExtensionsTests;

using System.Collections.Concurrent;
using System.Linq;

public sealed class WhenExtractIsCalled
{
    [Test]
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

    [Test]
    [Arguments(1)]
    [Arguments(10)]
    [Arguments(25)]
    [Arguments(50)]
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

    [Test]
    public void GivenANullCollectionAndACountThenAnEmptyEnumerableIsReturned()
    {
        // Arrange
        IProducerConsumerCollection<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Extract(count: 50);

        // Assert
        actual.ShouldBeEmpty();
    }

    [Test]
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