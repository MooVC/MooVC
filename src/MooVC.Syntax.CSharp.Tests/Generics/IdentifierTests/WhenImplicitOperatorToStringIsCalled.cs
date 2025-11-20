namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string IdentifierName = "TAlpha";

    [Fact]
    public void GivenIdentifierThenReturnsValue()
    {
        // Arrange
        var identifier = new Identifier(IdentifierName);

        // Act
        string value = identifier;

        // Assert
        value.ShouldBe(IdentifierName);
    }
}
