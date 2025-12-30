namespace MooVC.Syntax.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsTaskOutputIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        TaskOutput? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        TaskOutput other = TaskOutputTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        TaskOutput other = TaskOutputTestsData.Create(itemName: new Identifier("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}