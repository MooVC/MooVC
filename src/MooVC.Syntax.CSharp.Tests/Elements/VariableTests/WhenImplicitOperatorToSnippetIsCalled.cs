namespace MooVC.Syntax.CSharp.Elements.VariableTests;

using MooVC.Syntax.Elements;
using MooVC.Syntax.Formatting;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    private const string VariableName = "Variable";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Variable? variable = default;

        // Act
        Func<Snippet> result = () => variable;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenVariableThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Variable(VariableName);
        string expected = VariableName.ToCamelCase();

        // Act
        Snippet result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Snippet.From(expected));
    }
}