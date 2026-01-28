namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using Microsoft.Extensions.DependencyInjection;

public sealed class WhenAddZipWriterIsCalled
{
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

        // Assert
        _ = writer.ShouldBeOfType<ZipWriter>();
    }
}