namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithAliasIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Assembly original = AssemblyTestsData.Create();
        Snippet updated = Snippet.From("Other");

        // Act
        Assembly result = original.WithAlias(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Alias.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}