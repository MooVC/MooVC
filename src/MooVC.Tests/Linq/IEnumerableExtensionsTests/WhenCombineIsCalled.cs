namespace MooVC.Linq.IEnumerableExtensionsTests;

using System.Linq;

public sealed class WhenCombineIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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