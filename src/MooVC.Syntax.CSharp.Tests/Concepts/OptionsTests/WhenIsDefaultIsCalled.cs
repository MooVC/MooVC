namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.Elements;

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
        Options subject = new Options()
            .WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = subject.IsDefault;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}