namespace MooVC.Modelling.FileSystemWriterOptionsTests;

public sealed class WhenDefaultIsCalled
{
    private const int DefaultBufferSize = 4096;

    [Test]
    public async Task GivenDefaultThenBufferSizeIsSet()
    {
        // Arrange & Act
        FileSystemWriter.Options options = FileSystemWriter.Options.Default;

        // Assert
        _ = await Assert.That(options.BufferSize).IsEqualTo(DefaultBufferSize);
    }
}