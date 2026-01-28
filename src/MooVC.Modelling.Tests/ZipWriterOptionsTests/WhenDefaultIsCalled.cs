namespace MooVC.Modelling.ZipWriterOptionsTests;

using System.IO.Compression;

public sealed class WhenDefaultIsCalled
{
    [Fact]
    public void GivenDefaultThenCompressionIsOptimal()
    {
        // Arrange
        // Act
        ZipWriter.Options options = ZipWriter.Options.Default;

        // Assert
        options.Compression.ShouldBe(CompressionLevel.Optimal);
    }
}