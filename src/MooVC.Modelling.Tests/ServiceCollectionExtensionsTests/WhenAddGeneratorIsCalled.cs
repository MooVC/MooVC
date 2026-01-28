namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using Graphify;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenAddGeneratorIsCalled
{
    [Fact]
    public void GivenNullServicesThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        IServiceCollection services = null!;

        // Act
        Action action = () => services.AddGenerator();

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenServicesThenGeneratorIsRegistered()
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
        generator.ShouldBeOfType<Generator<TestModel>>();
    }

    private sealed class TestModel
    {
    }
}