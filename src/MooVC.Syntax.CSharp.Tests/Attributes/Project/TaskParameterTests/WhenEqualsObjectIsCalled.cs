namespace MooVC.Syntax.CSharp.Attributes.Project.TaskParameterTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        object other = TaskParameterTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}