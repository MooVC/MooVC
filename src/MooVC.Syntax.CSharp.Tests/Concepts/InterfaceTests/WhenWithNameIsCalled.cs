namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(name: new Declaration { Name = new Identifier("Original") });
        var name = new Declaration { Name = new Identifier("Updated") };

        // Act
        Interface result = original.WithName(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        original.Name.ShouldBe(new Declaration { Name = new Identifier("Original") });
    }
}
