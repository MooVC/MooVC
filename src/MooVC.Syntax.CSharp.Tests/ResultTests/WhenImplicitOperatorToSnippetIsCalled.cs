namespace MooVC.Syntax.CSharp.ResultTests;

public sealed class WhenImplicitOperatorToSnippetIsCalled
{
    [Test]
    public async Task GivenNullSubjectThenThrows()
    {
        // Arrange
        Result? subject = default;

        // Act
        Func<Snippet> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenResultThenSnippetMatchesToString()
    {
        // Arrange
        Result subject = ResultTestsData.Create(modifier: Result.Modifiers.Ref, mode: Result.Modes.Asynchronous);

        // Act
        Snippet result = subject;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(subject.ToString());
    }
}