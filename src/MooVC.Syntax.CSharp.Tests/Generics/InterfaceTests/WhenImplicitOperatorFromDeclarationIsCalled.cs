namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

public sealed class WhenImplicitOperatorFromDeclarationIsCalled
{
    [Test]
    public async Task GivenDeclarationThenCreatesInterface()
    {
        // Arrange
        var value = new Declaration { Name = "IAlpha" };

        // Act
        Interface result = value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(value.ToString());
    }

    [Test]
    public async Task GivenUnspecifiedDeclarationThenCreatesInterface()
    {
        // Arrange
        Declaration value = Declaration.Unspecified;

        // Act
        Interface result = value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(value.ToString());
    }
}