namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(name: new Declaration { Name = "Original" });
        var name = new Declaration { Name = "Updated" };

        // Act
        Interface result = original.Named(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Declaration.ShouldBe(name);
        original.Declaration.ShouldBe(new Declaration { Name = "Original" });
    }
}