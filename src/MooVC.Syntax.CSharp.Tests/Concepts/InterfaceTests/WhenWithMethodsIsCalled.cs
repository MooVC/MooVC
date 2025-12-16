namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithMethodsIsCalled
{
    [Fact]
    public void GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        var method = new Method { Name = new Identifier("Execute") };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithMethods(method);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Methods.ShouldContain(method);
        original.Methods.ShouldBeEmpty();
    }
}
