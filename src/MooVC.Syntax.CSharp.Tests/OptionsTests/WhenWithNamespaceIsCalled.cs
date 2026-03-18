namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenWithNamespaceIsCalled
{
    [Test]
    public async Task GivenNamespaceThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Options();

        // Act
        Options result = original.WithNamespace(Qualifier.Options.Block);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Namespace).IsEqualTo(Qualifier.Options.Block);
        _ = await Assert.That(result.Snippets).IsEqualTo(original.Snippets);
        _ = await Assert.That(original.Namespace).IsEqualTo(Qualifier.Options.File);
    }
}