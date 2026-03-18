namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNonBinaryObjectThenReturnsFalse()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenBinaryObjectThenReturnsResultOfBinaryEquals()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();
        object target = BinaryTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        await Assert.That(result).IsTrue();
    }
}