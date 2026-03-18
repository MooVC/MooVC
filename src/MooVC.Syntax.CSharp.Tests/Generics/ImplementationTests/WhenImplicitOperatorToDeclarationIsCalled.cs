namespace MooVC.Syntax.CSharp.Generics.Constraints.ImplementationTests;

public sealed class WhenImplicitOperatorToDeclarationIsCalled
{
    [Test]
    public async Task GivenImplementationThenReturnsDeclaration()
    {
        // Arrange
        Implementation subject = new Declaration { Name = "IAlpha" };

        // Act
        Declaration result = subject;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(subject.ToString());
    }
}