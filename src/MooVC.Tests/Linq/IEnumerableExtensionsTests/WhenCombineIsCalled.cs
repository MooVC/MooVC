namespace MooVC.Linq.IEnumerableExtensionsTests;

using System.Linq;

public sealed class WhenCombineIsCalled
{
    [Test]
    public async Task GivenAnInstanceAndASourceThenTheInstanceIsCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedValue = 9;
        const int ExpectedCount = 4;
        int[] source = [1, 2, 3];

        // Act
        IEnumerable<int> actual = source.Combine(ExpectedValue);

        // Assert
        _ = await Assert.That(actual.Count()).IsEqualTo(ExpectedCount);
        _ = await Assert.That(actual).Contains(ExpectedValue);
    }

    [Test]
    public async Task GivenAnInstanceAndANullSourceThenTheInstanceIsCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedValue = 9;
        IEnumerable<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Combine(ExpectedValue);

        // Assert
        _ = await Assert.That(actual.Single()).IsEqualTo(ExpectedValue);
    }

    [Test]
    public async Task GivenNoInstancesAndNoSourceThenAnEmptyEnumerationIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;
        IEnumerable<int>? expected = default;

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        _ = await Assert.That(actual).IsEmpty();
    }

    [Test]
    public async Task GivenInstancesAndASourceThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedCount = 6;
        IEnumerable<int>? source = [1, 2, 3];
        IEnumerable<int>? expected = [4, 5, 6];

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        _ = await Assert.That(actual.Count()).IsEqualTo(ExpectedCount);
        _ = await Assert.That(actual).IsEquivalentTo(source!.Concat(expected!));
    }

    [Test]
    public async Task GivenInstancesAndANullSourceThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        IEnumerable<int>? source = default;
        IEnumerable<int>? expected = [4, 5, 6];

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }
}