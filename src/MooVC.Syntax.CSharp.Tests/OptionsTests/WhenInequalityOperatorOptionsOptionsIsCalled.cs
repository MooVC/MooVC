namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenInequalityOperatorOptionsOptionsIsCalled
{
    [Test]
    public async Task GivenDifferentOptionsThenReturnsTrue()
    {
        // Arrange
        var left = new Options();
        Options right = new().WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentOptionsThenReturnsFalse()
    {
        // Arrange
        var left = new Options();
        var right = new Options();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}