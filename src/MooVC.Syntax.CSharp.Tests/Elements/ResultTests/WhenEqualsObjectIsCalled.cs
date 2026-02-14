namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNonResultObjectThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenResultObjectThenReturnsTrue()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        object other = ResultTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}