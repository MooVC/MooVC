namespace MooVC.Syntax.Attributes.Project.TargetTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Target subject = TargetTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        object other = TargetTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}