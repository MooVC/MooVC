namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyGroupTests;

public sealed class WhenEqualityOperatorPropertyGroupPropertyGroupIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        PropertyGroup? left = default;
        PropertyGroup? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}