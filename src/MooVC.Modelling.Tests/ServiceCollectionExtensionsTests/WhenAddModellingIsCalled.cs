namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.Compression;
using Graphify;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public sealed class WhenAddModellingIsCalled
{
    private const int CustomBufferSize = 2048;
    private const CompressionLevel CustomCompressionLevel = CompressionLevel.NoCompression;
    private const string FileSystemKey = "FileSystem";
    private const string ZipKey = "Zip";

    [Test]
    public async Task GivenServicesThenDependenciesAreRegistered()
    {
        // Arrange
        INavigator<TestModel> navigator = Substitute.For<INavigator<TestModel>>();
        ServiceCollection services = new();
        _ = services.AddSingleton(navigator);

        // Act
        _ = services.AddModelling();
        using ServiceProvider provider = services.BuildServiceProvider();
        IGenerator<TestModel> generator = provider.GetRequiredService<IGenerator<TestModel>>();
        IWriter fileSystemWriter = provider.GetRequiredKeyedService<IWriter>(FileSystemKey);
        IWriter zipWriter = provider.GetRequiredKeyedService<IWriter>(ZipKey);
        IOptionsSnapshot<FileSystemWriter.Options> fileSystemOptions = provider.GetRequiredService<IOptionsSnapshot<FileSystemWriter.Options>>();
        IOptionsSnapshot<ZipWriter.Options> zipOptions = provider.GetRequiredService<IOptionsSnapshot<ZipWriter.Options>>();

        // Assert
        _ = await Assert.That(generator).IsTypeOf<Generator<TestModel>>();
        _ = await Assert.That(fileSystemWriter).IsTypeOf<FileSystemWriter>();
        _ = await Assert.That(zipWriter).IsTypeOf<ZipWriter>();
        _ = await Assert.That(fileSystemOptions.Value.BufferSize).IsEqualTo(FileSystemWriter.Options.Default.BufferSize);
        _ = await Assert.That(zipOptions.Value.Compression).IsEqualTo(ZipWriter.Options.Default.Compression);
    }

    [Test]
    public async Task GivenConfigurationThenOptionsAreBound()
    {
        // Arrange
        var settings = new Dictionary<string, string?>
        {
            { $"{FileSystemWriter.Options.SectionName}:{nameof(FileSystemWriter.Options.BufferSize)}", CustomBufferSize.ToString(CultureInfo.InvariantCulture) },
            { $"{ZipWriter.Options.SectionName}:{nameof(ZipWriter.Options.Compression)}", CustomCompressionLevel.ToString() },
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();
        INavigator<TestModel> navigator = Substitute.For<INavigator<TestModel>>();
        ServiceCollection services = new();
        _ = services.AddSingleton(navigator);

        // Act
        _ = services.AddModelling(configuration);
        using ServiceProvider provider = services.BuildServiceProvider();
        IOptionsSnapshot<FileSystemWriter.Options> fileSystemOptions = provider.GetRequiredService<IOptionsSnapshot<FileSystemWriter.Options>>();
        IOptionsSnapshot<ZipWriter.Options> zipOptions = provider.GetRequiredService<IOptionsSnapshot<ZipWriter.Options>>();

        // Assert
        _ = await Assert.That(fileSystemOptions.Value.BufferSize).IsEqualTo(CustomBufferSize);
        _ = await Assert.That(zipOptions.Value.Compression).IsEqualTo(CustomCompressionLevel);
    }

    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty", Justification = "Class is empty for the purposes of the test.")]
    public sealed class TestModel;
}