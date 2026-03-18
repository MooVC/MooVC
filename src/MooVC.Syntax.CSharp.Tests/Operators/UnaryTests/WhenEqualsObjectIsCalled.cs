namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNonUnaryObjectThenReturnsFalse()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
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