namespace MooVC.Modelling.FileTests;

public sealed class WhenFilePathIsCalled
{
    private const string Content = "content";
    private const string Extension = "txt";
    private const string Name = "example";
    private const string PathValue = "Models";

    [Fact]
    public void GivenFileInformationThenFilePathIsReturned()
    {
        // Arrange
        File file = new(Content, Extension, Name, PathValue);
        string expectedFilePath = Path.Combine(PathValue, string.Concat(Name, ".", Extension));

        // Act
        string filePath = file.FilePath;

        // Assert
        filePath.ShouldBe(expectedFilePath);
    }
}