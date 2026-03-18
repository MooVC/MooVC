namespace MooVC.Syntax.Elements.PathTests;

using SystemPath = System.IO.Path;

public sealed class WhenDirectoryNameIsCalled
{
    [Test]
    public async Task GivenPathThenReturnsDirectoryName()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string? expected = SystemPath.GetDirectoryName(PathTestsData.DefaultPath);

        // Act
        string result = subject.DirectoryName;

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}