namespace MooVC.Syntax.Elements.PathTests;

using SystemPath = System.IO.Path;

public sealed class WhenExtensionIsCalled
{
    [Fact]
    public void GivenPathThenReturnsExtension()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string expected = SystemPath.GetExtension(PathTestsData.DefaultPath);

        // Act
        string result = subject.Extension;

        // Assert
        result.ShouldBe(expected);
    }
}