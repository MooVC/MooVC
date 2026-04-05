namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenIsDefaultIsCalled
{
    [Test]
    public async Task GivenDefaultValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Options();

        // Act
        bool result = subject.IsDefault;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonDefaultValuesThenReturnsFalse()
    {
        // Arrange
        Options subject = new()
            .WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = subject.IsDefault;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}