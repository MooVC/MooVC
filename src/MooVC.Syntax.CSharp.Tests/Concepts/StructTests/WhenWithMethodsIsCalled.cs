namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithMethodsIsCalled
{
    [Fact]
    public void GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        var method = new Method { Name = new Identifier("Execute") };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithMethods(method);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Methods.ShouldContain(method);
        original.Methods.ShouldBeEmpty();
    }
}
