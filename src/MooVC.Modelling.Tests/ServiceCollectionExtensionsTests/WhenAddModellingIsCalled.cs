namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using Graphify;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenAddModellingIsCalled
{
    private const string FileSystemKey = "FileSystem";
    private const string ZipKey = "Zip";

    [Fact]
    public void GivenServicesThenDependenciesAreRegistered()
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

        // Assert
        generator.ShouldBeOfType<Generator<TestModel>>();
        fileSystemWriter.ShouldBeOfType<FileSystemWriter>();
        zipWriter.ShouldBeOfType<ZipWriter>();
    }

    private sealed class TestModel
    {
    }
}