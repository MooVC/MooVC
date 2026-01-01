namespace MooVC.Syntax.CSharp.Elements.VariableTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string VariableName = "Variable";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Variable? variable = default;

        // Act
        Func<Snippet> result = () => variable;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenVariableThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Variable(VariableName);
        string expected = VariableName.ToCamelCase();

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(expected));
    }
}