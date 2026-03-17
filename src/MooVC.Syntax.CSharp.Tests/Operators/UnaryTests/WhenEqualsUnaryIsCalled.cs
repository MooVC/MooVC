namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenEqualsUnaryIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Unary? subject = default;
        Unary target = UnaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        Unary target = UnaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        Unary target = UnaryTestsData.Create(@operator: Unary.Type.Minus);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}