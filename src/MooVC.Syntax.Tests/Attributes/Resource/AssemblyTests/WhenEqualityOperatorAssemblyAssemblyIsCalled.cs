namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorAssemblyAssemblyIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Assembly? left = default;
        Assembly? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Assembly? left = default;
        Assembly right = AssemblyTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Assembly left = AssemblyTestsData.Create();
        Assembly right = AssemblyTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Assembly left = AssemblyTestsData.Create();
        Assembly right = AssemblyTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}