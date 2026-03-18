namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Attribute.Specifier? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenSpecifierThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Property;

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject.ToString()));
    }
}