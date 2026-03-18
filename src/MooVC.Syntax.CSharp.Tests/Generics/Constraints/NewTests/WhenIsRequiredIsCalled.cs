namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenIsRequiredIsCalled
{
    [Test]
    public async Task GivenRequiredValueThenReturnsTrue()
    {
        // Arrange
        New subject = New.Required;

        // Act
        bool result = subject.IsRequired;

        // Assert
        await Assert.That(result).IsTrue();
        await Assert.That(subject.IsNotRequired).IsFalse();
    }

    [Test]
    public async Task GivenNonRequiredValueThenReturnsFalse()
    {
        // Arrange
        New subject = New.NotRequired;

        // Act
        bool result = subject.IsRequired;

        // Assert
        await Assert.That(result).IsFalse();
        await Assert.That(subject.IsNotRequired).IsTrue();
    }
}