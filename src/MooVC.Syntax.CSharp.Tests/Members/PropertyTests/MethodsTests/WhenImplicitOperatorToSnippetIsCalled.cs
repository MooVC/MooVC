namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullMethodsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Property.Methods? subject = default;

        // Act
        Func<Snippet> result = () => subject!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenMethodsThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        string expected = subject.ToString();

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(expected);
    }
}