namespace MooVC.Modelling.FileSystemWriterOptionsTests;

public sealed class WhenFileSystemWriterOptionsIsConstructed
{
    [Test]
    public async Task GivenDefaultConstructorThenDefaultValuesAreApplied()
    {
        // Arrange
        // Act
        FileSystemWriter.Options options = new();

        // Assert
        _ = await Assert.That(options.BufferSize).IsEqualTo(FileSystemWriter.Options.Default.BufferSize);
    }
}