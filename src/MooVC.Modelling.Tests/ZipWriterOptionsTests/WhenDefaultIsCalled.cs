namespace MooVC.Modelling.ZipWriterOptionsTests;

using System.IO.Compression;

public sealed class WhenDefaultIsCalled
{
    [Test]
    public async Task GivenDefaultThenCompressionIsOptimal()
    {
        // Arrange
        // Act
        ZipWriter.Options options = ZipWriter.Options.Default;

        // Assert
        _ = await Assert.That(options.Compression).IsEqualTo(CompressionLevel.Optimal);
    }
}