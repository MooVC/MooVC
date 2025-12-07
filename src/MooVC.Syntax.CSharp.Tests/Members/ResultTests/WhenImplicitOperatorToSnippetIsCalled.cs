namespace MooVC.Syntax.CSharp.Members.ResultTests;

using System;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Result? subject = default;

        // Act
        Func<Snippet> result = () => subject!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenResultThenSnippetMatchesToSnippet()
    {
        // Arrange
        Result subject = ResultTestsData.Create();

        // Act
        Snippet result = subject;

        // Assert
        result.ShouldBe(Snippet.From(subject));
    }
}
