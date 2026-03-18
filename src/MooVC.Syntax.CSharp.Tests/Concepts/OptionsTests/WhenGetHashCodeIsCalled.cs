namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualOptionsThenHashCodesMatch()
    {
        // Arrange
        var left = new Options();
        var right = new Options();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }

    [Test]
    public async Task GivenDifferentOptionsThenHashCodesDiffer()
    {
        // Arrange
        var left = new Options();
        Options right = new Options().WithNamespace(Qualifier.Options.Block);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }
}