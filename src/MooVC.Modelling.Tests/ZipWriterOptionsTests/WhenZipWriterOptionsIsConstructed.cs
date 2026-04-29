namespace MooVC.Modelling.ZipWriterOptionsTests;

public sealed class WhenZipWriterOptionsIsConstructed
{
    [Test]
    public async Task GivenDefaultConstructorThenDefaultValuesAreApplied()
    {
        // Arrange
        // Act
        ZipWriter.Options options = new();

        // Assert
        _ = await Assert.That(options.Compression).IsEqualTo(ZipWriter.Options.Default.Compression);
    }
}