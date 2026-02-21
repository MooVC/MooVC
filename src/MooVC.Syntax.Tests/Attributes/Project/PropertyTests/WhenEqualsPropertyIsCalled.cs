namespace MooVC.Syntax.Attributes.Project.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsPropertyIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property other = PropertyTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property other = PropertyTestsData.Create(name: new Name("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}