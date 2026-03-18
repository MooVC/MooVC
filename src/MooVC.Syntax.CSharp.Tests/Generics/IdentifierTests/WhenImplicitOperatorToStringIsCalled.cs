namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string IdentifierName = "TAlpha";

    [Test]
    public async Task GivenIdentifierThenReturnsValue()
    {
        // Arrange
        var identifier = new Identifier(IdentifierName);

        // Act
        string value = identifier;

        // Assert
        _ = await Assert.That(value).IsEqualTo(IdentifierName);
    }
}