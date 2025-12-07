namespace MooVC.Syntax.CSharp.Members.ResultTests;

using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenDefaultResultThenReturnsExpectedRepresentation()
    {
        // Arrange
        Result subject = ResultTestsData.Create();

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(" ".Combine(subject.Mode, subject.Modifier, subject.Type));
    }

    [Fact]
    public void GivenSynchronousVoidResultThenReturnsEmpty()
    {
        // Arrange
        Result subject = Result.Void;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(" ".Combine(subject.Mode, subject.Modifier, subject.Type));
    }
}
