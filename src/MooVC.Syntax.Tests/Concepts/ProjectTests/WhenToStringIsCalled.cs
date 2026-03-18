namespace MooVC.Syntax.Concepts.ProjectTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsDocumentString()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(subject.ToDocument().ToString());
    }
}