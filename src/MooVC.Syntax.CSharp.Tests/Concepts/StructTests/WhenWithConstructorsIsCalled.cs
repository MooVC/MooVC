namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithConstructorsIsCalled
{
    [Fact]
    public void GivenConstructorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var constructor = new Constructor { Scope = Scope.Protected };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithConstructors(constructor);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Constructors.ShouldContain(constructor);
        original.Constructors.ShouldBeEmpty();
    }
}