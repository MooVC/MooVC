namespace MooVC.Linq.IEnumerableExtensionsTests;

using System.Linq;

public sealed class WhenCombineIsCalled
{
    [Test]
    public void GivenAnInstanceAndASourceThenTheInstanceIsCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedValue = 9;
        const int ExpectedCount = 4;
        int[] source = [1, 2, 3];

        // Act
        IEnumerable<int> actual = source.Combine(ExpectedValue);

        // Assert
        actual.Count().ShouldBe(ExpectedCount);
        actual.ShouldContain(ExpectedValue);
    }

    [Test]
    public void GivenAnInstanceAndANullSourceThenTheInstanceIsCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedValue = 9;
        IEnumerable<int>? source = default;

        // Act
        IEnumerable<int> actual = source.Combine(ExpectedValue);

        // Assert
        actual.ShouldHaveSingleItem().ShouldBe(ExpectedValue);
    }

    [Test]
    public void GivenNoInstancesAndNoSourceThenAnEmptyEnumerationIsReturned()
    {
        // Arrange
        IEnumerable<int>? source = default;
        IEnumerable<int>? expected = default;

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        actual.ShouldBeEmpty();
    }

    [Test]
    public void GivenInstancesAndASourceThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedCount = 6;
        IEnumerable<int>? source = [1, 2, 3];
        IEnumerable<int>? expected = [4, 5, 6];

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        actual.Count().ShouldBe(ExpectedCount);
        actual.ShouldBe(source!.Concat(expected!));
    }

    [Test]
    public void GivenInstancesAndANullSourceThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        IEnumerable<int>? source = default;
        IEnumerable<int>? expected = [4, 5, 6];

        // Act
        IEnumerable<int> actual = source.Combine(expected);

        // Assert
        actual.ShouldBe(expected);
    }
}