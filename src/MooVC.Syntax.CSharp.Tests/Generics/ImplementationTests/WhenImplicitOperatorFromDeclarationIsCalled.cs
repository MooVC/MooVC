namespace MooVC.Syntax.CSharp.Generics.Constraints.ImplementationTests;

public sealed class WhenImplicitOperatorFromDeclarationIsCalled
{
    [Test]
    public async Task GivenDeclarationThenCreatesImplementation()
    {
        // Arrange
        var value = new Declaration { Name = "IAlpha" };

        // Act
        Implementation result = value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(value.ToString());
    }

    [Test]
    public async Task GivenUnspecifiedDeclarationThenCreatesImplementation()
    {
        // Arrange
        Declaration value = Declaration.Unspecified;

        // Act
        Implementation result = value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(value.ToString());
    }
}