namespace MooVC.Syntax.Attributes.Project.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsPropertyIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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