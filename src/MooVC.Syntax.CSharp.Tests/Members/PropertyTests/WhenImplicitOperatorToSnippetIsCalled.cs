namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Property? subject = default;

        // Act
        Func<Snippet> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenPropertyThenSnippetMatchesStringRepresentation()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        string expected = subject.ToString();

        // Act
        Snippet result = subject;

        // Assert
        result.ToString().ShouldBe(expected);
    }
}