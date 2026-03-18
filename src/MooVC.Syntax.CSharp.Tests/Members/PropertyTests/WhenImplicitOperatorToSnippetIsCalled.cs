namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Property? subject = default;

        // Act
        Func<Snippet> result = () => subject!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenPropertyThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        string expected = subject.ToString();

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(expected);
    }
}