namespace MooVC.Syntax.CSharp.VariableTests;

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
        _ = await Assert.That(result).Throws<ArgumentNullException>();
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
        _ = await Assert.That(result).IsEqualTo(Snippet.From(expected));
    }
}