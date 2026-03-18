namespace MooVC.Syntax.Concepts.ResourceTests;

using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenEqualsResourceIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        Resource? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        Resource other = ResourceTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        Resource other = ResourceTestsData.Create(data: Data.Undefined);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}