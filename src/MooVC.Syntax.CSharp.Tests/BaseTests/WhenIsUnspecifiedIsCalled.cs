namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Test]
    public async Task GivenSpecifiedBaseThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = "Base" };

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenUnspecifiedBaseThenReturnsTrue()
    {
        // Arrange
        Base subject = Base.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}