namespace MooVC.Syntax.Attributes.Solution.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorPropertyPropertyIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Property? left = default;
        Property? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Property left = PropertyTestsData.Create();
        Property right = PropertyTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Property left = PropertyTestsData.Create();
        Property right = PropertyTestsData.Create(value: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}