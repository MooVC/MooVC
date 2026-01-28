namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public sealed class WhenAddZipWriterIsCalled
{
    private const CompressionLevel CustomCompressionLevel = CompressionLevel.NoCompression;
    private const string ZipKey = "Zip";

    [Fact]
    public void GivenNullServicesThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        IServiceCollection services = null!;

        // Act
        Action action = () => services.AddZipWriter();

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenServicesThenWriterIsRegistered()
    {
        // Arrange
        ServiceCollection services = new();

        // Act
        _ = services.AddZipWriter();
        using ServiceProvider provider = services.BuildServiceProvider();
        IWriter writer = provider.GetRequiredKeyedService<IWriter>(ZipKey);
        IOptionsSnapshot<ZipWriter.Options> options = provider.GetRequiredService<IOptionsSnapshot<ZipWriter.Options>>();

        // Assert
        _ = writer.ShouldBeOfType<ZipWriter>();
        options.Value.Compression.ShouldBe(ZipWriter.Options.Default.Compression);
    }

    [Fact]
    public void GivenConfigurationThenOptionsAreBound()
    {
        // Arrange
        var settings = new Dictionary<string, string?>
        {
            { $"{ZipWriter.Options.SectionName}:{nameof(ZipWriter.Options.Compression)}", CustomCompressionLevel.ToString() },
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();
        ServiceCollection services = new();

        // Act
        _ = services.AddZipWriter(configuration);
        using ServiceProvider provider = services.BuildServiceProvider();
        IOptionsSnapshot<ZipWriter.Options> options = provider.GetRequiredService<IOptionsSnapshot<ZipWriter.Options>>();

        // Assert
        options.Value.Compression.ShouldBe(CustomCompressionLevel);
    }
}