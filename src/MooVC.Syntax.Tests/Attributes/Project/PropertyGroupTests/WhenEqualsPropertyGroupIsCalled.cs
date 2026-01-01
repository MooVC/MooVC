namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsPropertyGroupIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();
        PropertyGroup? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();
        PropertyGroup other = PropertyGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();
        PropertyGroup other = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}