namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorToDeclarationIsCalled
{
    [Test]
    public async Task GivenInterfaceThenReturnsDeclaration()
    {
        // Arrange
        Interface subject = new Declaration { Name = "IAlpha" };

        // Act
        Declaration result = subject;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(subject.ToString());
    }
}