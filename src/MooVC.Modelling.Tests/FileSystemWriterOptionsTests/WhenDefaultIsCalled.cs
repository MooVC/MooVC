namespace MooVC.Modelling.FileSystemWriterOptionsTests;

public sealed class WhenDefaultIsCalled
{
    private const int DefaultBufferSize = 4096;

    [Fact]
    public void GivenDefaultThenBufferSizeIsSet()
    {
        // Arrange & Act
        FileSystemWriter.Options options = FileSystemWriter.Options.Default;

        // Assert
        options.BufferSize.ShouldBe(DefaultBufferSize);
    }
}