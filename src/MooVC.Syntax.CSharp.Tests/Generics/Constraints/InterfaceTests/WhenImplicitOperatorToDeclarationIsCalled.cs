namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorToDeclarationIsCalled
{
    [Fact]
    public void GivenInterfaceThenReturnsDeclaration()
    {
        // Arrange
        Interface subject = new Declaration { Name = "IAlpha" };

        // Act
        Declaration result = subject;

        // Assert
        result.ToString().ShouldBe(subject.ToString());
    }
}