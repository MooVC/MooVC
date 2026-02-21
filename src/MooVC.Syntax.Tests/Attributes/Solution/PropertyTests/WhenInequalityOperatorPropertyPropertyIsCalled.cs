namespace MooVC.Syntax.Attributes.Solution.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorPropertyPropertyIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property? left = default;
        Property? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Property left = PropertyTestsData.Create();
        Property right = PropertyTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Property left = PropertyTestsData.Create();
        Property right = PropertyTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}