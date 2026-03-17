namespace MooVC.Syntax.CSharp.Elements.VariableTests;

using MooVC.Syntax.Elements;
using MooVC.Syntax.Formatting;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string VariableName = "Variable";

    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Variable? variable = default;

        // Act
        Func<Snippet> result = () => variable;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
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