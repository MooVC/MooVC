namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(name: new Declaration { Name = new Variable("Original") });
        var name = new Declaration { Name = new Variable("Updated") };

        // Act
        Struct result = original.Named(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        original.Name.ShouldBe(new Declaration { Name = new Variable("Original") });
    }
}