namespace MooVC.Modelling.GeneratorTests;

using System.Collections.Generic;
using Graphify;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenGenerateIsCalled
{
    private const string Content = "content";
    private const string Extension = "txt";
    private const string Name = "example";
    private const string PathValue = "Models";

    [Fact]
    public async Task GivenNavigatorThenFilesAreReturned()
    {
        // Arrange
        TestModel model = new();
        File expectedFile = new(Content, Extension, Name, PathValue);
        IAsyncEnumerable<File> files = CreateFiles(expectedFile);
        INavigator<TestModel> navigator = Substitute.For<INavigator<TestModel>>();
        _ = navigator
            .Navigate<File>(model, Arg.Any<CancellationToken>())
            .Returns(files);

        ServiceCollection services = new();
        _ = services.AddSingleton(navigator);
        IServiceProvider provider = services.BuildServiceProvider();
        IGenerator<TestModel> generator = new Generator<TestModel>(provider);

        // Act
        IReadOnlyList<File> results = await Materialize(generator.Generate(model, CancellationToken.None));

        // Assert
        results.Count.ShouldBe(1);
        results[0].ShouldBe(expectedFile);
        _ = navigator.Received(1).Navigate<File>(model, Arg.Any<CancellationToken>());
    }

    private static async IAsyncEnumerable<File> CreateFiles(params File[] files)
    {
        foreach (File file in files)
        {
            yield return file;
            await Task.Yield();
        }
    }

    private static async Task<IReadOnlyList<File>> Materialize(IAsyncEnumerable<File> files)
    {
        List<File> results = new();

        await foreach (File file in files)
        {
            results.Add(file);
        }

        return results;
    }

    private sealed class TestModel
    {
    }
}