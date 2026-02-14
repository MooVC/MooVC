namespace MooVC.Modelling.ServiceCollectionExtensionsTests;

using System.Diagnostics.CodeAnalysis;
using Graphify;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenAddGeneratorIsCalled
{
    [Fact]
    public void GivenNullServicesThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        IServiceCollection services = default!;

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
        _ = generator.ShouldBeOfType<Generator<TestModel>>();
    }

    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty", Justification = "Class is empty for the purposes of the test.")]
    public sealed class TestModel;
}