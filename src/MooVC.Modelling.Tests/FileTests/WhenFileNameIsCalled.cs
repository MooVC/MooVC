namespace MooVC.Modelling.FileTests;

public sealed class WhenFileNameIsCalled
{
    private const string Content = "content";
    private const string Extension = "txt";
    private const string Name = "example";
    private const string PathValue = "Models";

    [Fact]
    public void GivenNameAndExtensionThenFileNameIsReturned()
    {
        // Arrange
        File file = new(Content, Extension, Name, PathValue);
        string expectedFileName = string.Concat(Name, ".", Extension);

        // Act
        string fileName = file.FullName;

        // Assert
        fileName.ShouldBe(expectedFileName);
    }
}