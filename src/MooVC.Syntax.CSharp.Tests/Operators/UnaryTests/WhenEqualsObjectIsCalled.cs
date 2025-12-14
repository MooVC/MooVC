namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNonUnaryObjectThenReturnsFalse()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenUnaryObjectThenReturnsResultOfUnaryEquals()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        object target = UnaryTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }
}
