namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(name: new Declaration { Name = new Identifier("Original") });
        var name = new Declaration { Name = new Identifier("Updated") };

        // Act
        Struct result = original.WithName(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        original.Name.ShouldBe(new Declaration { Name = new Identifier("Original") });
    }
}