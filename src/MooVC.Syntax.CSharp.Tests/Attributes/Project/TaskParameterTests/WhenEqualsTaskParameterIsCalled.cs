namespace MooVC.Syntax.CSharp.Attributes.Project.TaskParameterTests;

public sealed class WhenEqualsTaskParameterIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        TaskParameter? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        TaskParameter other = TaskParameterTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        TaskParameter other = TaskParameterTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}