namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNonUnaryObjectThenReturnsFalse()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenUnaryObjectThenReturnsResultOfUnaryEquals()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        object target = UnaryTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        await Assert.That(result).IsTrue();
    }
}