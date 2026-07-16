namespace MooVC.Syntax.CSharp.UnaryTests;

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
        _ = await Assert.That(result).IsFalse();
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
        _ = await Assert.That(result).IsTrue();
    }
}