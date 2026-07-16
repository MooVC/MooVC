namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenMethodObjectThenReturnsResultOfMethodEquals()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        object target = MethodTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonMethodObjectThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}