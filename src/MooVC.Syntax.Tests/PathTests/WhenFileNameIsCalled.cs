namespace MooVC.Syntax.PathTests;

using SystemPath = System.IO.Path;

public sealed class WhenFileNameIsCalled
{
    [Test]
    public async Task GivenPathThenReturnsFileName()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string expected = SystemPath.GetFileName(PathTestsData.DefaultPath);

        // Act
        string result = subject.FileName;

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}