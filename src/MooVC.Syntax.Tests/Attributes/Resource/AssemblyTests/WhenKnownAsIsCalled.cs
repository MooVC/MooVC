namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Assembly original = AssemblyTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Assembly result = original.KnownAs(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Alias.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}