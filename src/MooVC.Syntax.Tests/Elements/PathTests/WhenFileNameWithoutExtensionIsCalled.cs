namespace MooVC.Syntax.Elements.PathTests;

using SystemPath = System.IO.Path;

public sealed class WhenFileNameWithoutExtensionIsCalled
{
    [Fact]
    public void GivenPathThenReturnsFileNameWithoutExtension()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string expected = SystemPath.GetFileNameWithoutExtension(PathTestsData.DefaultPath);

        // Act
        string result = subject.FileNameWithoutExtension;

        // Assert
        result.ShouldBe(expected);
    }
}