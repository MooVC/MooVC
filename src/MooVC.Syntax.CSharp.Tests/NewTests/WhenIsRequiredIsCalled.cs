namespace MooVC.Syntax.CSharp.NewTests;

public sealed class WhenIsRequiredIsCalled
{
    [Test]
    public async Task GivenNonRequiredValueThenReturnsFalse()
    {
        // Arrange
        New subject = New.NotRequired;

        // Act
        bool result = subject.IsRequired;

        // Assert
        _ = await Assert.That(result).IsFalse();
        _ = await Assert.That(subject.IsNotRequired).IsTrue();
    }

    [Test]
    public async Task GivenRequiredValueThenReturnsTrue()
    {
        // Arrange
        New subject = New.Required;

        // Act
        bool result = subject.IsRequired;

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(subject.IsNotRequired).IsFalse();
    }
}