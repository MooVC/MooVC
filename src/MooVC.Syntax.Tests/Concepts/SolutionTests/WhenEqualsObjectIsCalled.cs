namespace MooVC.Syntax.Concepts.SolutionTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();
        object other = SolutionTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}