namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorPropertyPropertyIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Property left = PropertyTestsData.Create();
        Property right = PropertyTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}