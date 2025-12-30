namespace MooVC.Syntax.Concepts.ProjectTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsDocumentString()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(subject.ToDocument().ToString());
    }
}