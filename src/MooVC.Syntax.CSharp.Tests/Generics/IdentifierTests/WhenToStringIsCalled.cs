namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenToStringIsCalled
{
    private const string Value = "TResult";

    [Fact]
    public void GivenNamedIdentifierThenReturnsValue()
    {
        // Arrange
        var subject = new Identifier(Value);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Value);
    }

    [Fact]
    public void GivenUnnamedIdentifierThenReturnsEmpty()
    {
        // Arrange
        Identifier subject = Identifier.Unnamed;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }
}