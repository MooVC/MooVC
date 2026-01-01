namespace MooVC.Syntax.CSharp.Elements.ResultTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenThrows()
    {
        // Arrange
        Result? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenResultThenSnippetMatchesToString()
    {
        // Arrange
        Result subject = ResultTestsData.Create(modifier: Result.Kind.Ref, mode: Result.Modality.Asynchronous);

        // Act
        Snippet result = subject;

        // Assert
        result.ToString().ShouldBe(subject.ToString());
    }
}