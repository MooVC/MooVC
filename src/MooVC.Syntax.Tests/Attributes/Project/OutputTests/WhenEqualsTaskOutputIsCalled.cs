namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsTaskOutputIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Output subject = OutputTestsData.Create();
        Output? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Output subject = OutputTestsData.Create();
        Output other = OutputTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Output subject = OutputTestsData.Create();
        Output other = OutputTestsData.Create(itemName: new Name("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}