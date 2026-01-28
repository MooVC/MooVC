namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using System.Diagnostics.CodeAnalysis;
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
        _ = generator.ShouldBeOfType<Generator<TestModel>>();
        _ = fileSystemWriter.ShouldBeOfType<FileSystemWriter>();
        _ = zipWriter.ShouldBeOfType<ZipWriter>();
    }

    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty", Justification = "Class is empty for the purposes of the test.")]
    public sealed class TestModel;
}