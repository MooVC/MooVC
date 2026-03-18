namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenEqualsUnaryIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Unary? subject = default;
        Unary target = UnaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        Unary target = UnaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        Unary target = UnaryTestsData.Create(@operator: Unary.Type.Minus);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}