namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Attribute.Specifiers? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenSpecifierThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Attribute.Specifiers subject = Attribute.Specifiers.Property;

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.From(subject.ToString()));
    }
}