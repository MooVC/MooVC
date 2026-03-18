namespace MooVC.Syntax.Elements.PathTests;

using SystemPath = System.IO.Path;

public sealed class WhenFileNameWithoutExtensionIsCalled
{
    [Test]
    public async Task GivenPathThenReturnsFileNameWithoutExtension()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string expected = SystemPath.GetFileNameWithoutExtension(PathTestsData.DefaultPath);

        // Act
        string result = subject.FileNameWithoutExtension;

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}