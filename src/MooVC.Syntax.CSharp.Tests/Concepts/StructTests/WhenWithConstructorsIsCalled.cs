namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithConstructorsIsCalled
{
    [Fact]
    public void GivenConstructorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var constructor = new Constructor { Name = new Declaration { Name = new Identifier("Constructor") } };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithConstructors(constructor);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Constructors.ShouldContain(constructor);
        original.Constructors.ShouldBeEmpty();
    }
}
