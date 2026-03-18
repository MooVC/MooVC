namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Test]
    public async Task GivenEquivalentOptionsThenReturnsTrue()
    {
        // Arrange
        var left = new Options();
        var right = new Options();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentOptionsThenReturnsFalse()
    {
        // Arrange
        var left = new Options();
        Options right = new Options().WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}