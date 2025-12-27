namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithNamespaceIsCalled
{
    [Fact]
    public void GivenNamespaceThenReturnsUpdatedInstance()
    {
        // Arrange
        Options original = new Options();

        // Act
        Options result = original.WithNamespace(Qualifier.Options.Block);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Namespace.ShouldBe(Qualifier.Options.Block);
        result.Snippets.ShouldBe(original.Snippets);
        original.Namespace.ShouldBe(Qualifier.Options.File);
    }
}