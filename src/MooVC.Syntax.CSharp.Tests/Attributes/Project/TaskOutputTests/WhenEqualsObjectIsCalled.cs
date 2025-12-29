namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        object other = TaskOutputTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}