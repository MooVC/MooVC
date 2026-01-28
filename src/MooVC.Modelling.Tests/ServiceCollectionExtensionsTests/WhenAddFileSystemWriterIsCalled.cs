namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using Microsoft.Extensions.DependencyInjection;

public sealed class WhenAddFileSystemWriterIsCalled
{
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

        // Assert
        writer.ShouldBeOfType<FileSystemWriter>();
        fileSystem.ShouldNotBeNull();
    }
}