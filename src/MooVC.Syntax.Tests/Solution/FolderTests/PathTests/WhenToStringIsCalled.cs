namespace MooVC.Syntax.Solution.FolderTests.PathTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        const string path = "/Folder/";
        var subject = new Folder.Path(path);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(path);
    }
}