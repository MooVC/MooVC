namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorAssemblyAssemblyIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Assembly? left = default;
        Assembly? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Assembly? left = default;
        Assembly right = AssemblyTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Assembly left = AssemblyTestsData.Create();
        Assembly right = AssemblyTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Assembly left = AssemblyTestsData.Create();
        Assembly right = AssemblyTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}