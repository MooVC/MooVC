namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public sealed class WhenAddFileSystemWriterIsCalled
{
    private const int CustomBufferSize = 8192;
    private const string FileSystemKey = "FileSystem";

    [Test]
    public async Task GivenNullServicesThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        IServiceCollection services = default!;

        // Act
        Action action = () => services.AddFileSystemWriter();

        // Assert
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenServicesThenWriterIsRegistered()
    {
        // Arrange
        ServiceCollection services = new();

        // Act
        _ = services.AddFileSystemWriter();
        using ServiceProvider provider = services.BuildServiceProvider();
        IWriter writer = provider.GetRequiredKeyedService<IWriter>(FileSystemKey);
        IFileSystem fileSystem = provider.GetRequiredService<IFileSystem>();
        IOptionsSnapshot<FileSystemWriter.Options> options = provider.GetRequiredService<IOptionsSnapshot<FileSystemWriter.Options>>();

        // Assert
        _ = await Assert.That(writer).IsTypeOf<FileSystemWriter>();
        _ = await Assert.That(fileSystem).IsNotNull();
        _ = await Assert.That(options.Value.BufferSize).IsEqualTo(FileSystemWriter.Options.Default.BufferSize);
    }

    [Test]
    public async Task GivenConfigurationThenOptionsAreBound()
    {
        // Arrange
        var settings = new Dictionary<string, string?>
        {
            { $"{FileSystemWriter.Options.SectionName}:{nameof(FileSystemWriter.Options.BufferSize)}", CustomBufferSize.ToString(CultureInfo.InvariantCulture) },
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();

        ServiceCollection services = new();

        // Act
        _ = services.AddFileSystemWriter(configuration);
        using ServiceProvider provider = services.BuildServiceProvider();
        IOptionsSnapshot<FileSystemWriter.Options> options = provider.GetRequiredService<IOptionsSnapshot<FileSystemWriter.Options>>();

        // Assert
        _ = await Assert.That(options.Value.BufferSize).IsEqualTo(CustomBufferSize);
    }
}