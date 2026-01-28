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

    [Fact]
    public void GivenNullServicesThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        IServiceCollection services = null!;

        // Act
        Action action = () => services.AddFileSystemWriter();

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenServicesThenWriterIsRegistered()
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
        _ = writer.ShouldBeOfType<FileSystemWriter>();
        _ = fileSystem.ShouldNotBeNull();
        options.Value.BufferSize.ShouldBe(FileSystemWriter.Options.Default.BufferSize);
    }

    [Fact]
    public void GivenConfigurationThenOptionsAreBound()
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
        options.Value.BufferSize.ShouldBe(CustomBufferSize);
    }
}