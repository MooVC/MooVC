namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Namespace).IsEqualTo(Qualifier.Options.Block);
        await Assert.That(result.Snippets).IsEqualTo(original.Snippets);
        await Assert.That(original.Namespace).IsEqualTo(Qualifier.Options.File);
    }
}