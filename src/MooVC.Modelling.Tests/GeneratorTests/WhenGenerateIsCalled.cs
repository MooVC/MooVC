namespace MooVC.Modelling.GeneratorTests;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Graphify;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenGenerateIsCalled
{
    private const string Content = "content";
    private const string Extension = "txt";
    private const string Name = "example";
    private const string PathValue = "Models";

    [Test]
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
        _ = await Assert.That(results).HasSingleItem();
        _ = await Assert.That(results[0]).IsEqualTo(expectedFile);
        _ = navigator.Received(1).Navigate<File>(model, Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task GivenNavigatorIsNotRegisteredThenInvalidOperationExceptionIsThrown()
    {
        // Arrange
        TestModel model = new();
        ServiceCollection services = new();
        IServiceProvider provider = services.BuildServiceProvider();
        IGenerator<TestModel> generator = new Generator<TestModel>(provider);

        // Act
        Func<IAsyncEnumerable<File>> action = () => generator.Generate(model, CancellationToken.None);

        // Assert
        _ = await Assert.That(action).Throws<InvalidOperationException>();
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
        List<File> results = [];

        await foreach (File file in files)
        {
            results.Add(file);
        }

        return results;
    }

    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty", Justification = "Class is empty for the purposes of the test.")]
    public sealed class TestModel;
}