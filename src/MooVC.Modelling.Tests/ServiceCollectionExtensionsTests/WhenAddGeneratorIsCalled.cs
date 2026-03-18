namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using System.Diagnostics.CodeAnalysis;
using Graphify;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenAddGeneratorIsCalled
{
    [Test]
    public async Task GivenNullServicesThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        IServiceCollection services = default!;

        // Act
        Action action = () => services.AddGenerator();

        // Assert
        await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenServicesThenGeneratorIsRegistered()
    {
        // Arrange
        INavigator<TestModel> navigator = Substitute.For<INavigator<TestModel>>();
        ServiceCollection services = new();
        _ = services.AddSingleton(navigator);

        // Act
        _ = services.AddGenerator();
        using ServiceProvider provider = services.BuildServiceProvider();
        IGenerator<TestModel> generator = provider.GetRequiredService<IGenerator<TestModel>>();

        // Assert
        await Assert.That(generator).IsTypeOf<Generator<TestModel>>();
    }

    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty", Justification = "Class is empty for the purposes of the test.")]
    public sealed class TestModel;
}