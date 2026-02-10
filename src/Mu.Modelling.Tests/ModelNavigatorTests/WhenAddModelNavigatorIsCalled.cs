namespace Mu.Modelling.ModelNavigatorTests;

using Graphify;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenAddModelNavigatorIsCalled
{
    [Fact]
    public void GivenServicesThenNavigatorIsRegistered()
    {
        // Arrange
        ServiceCollection services = new();

        // Act
        _ = services.AddModelNavigator();
        using ServiceProvider provider = services.BuildServiceProvider();
        INavigator<Model>? navigator = provider.GetService<INavigator<Model>>();

        // Assert
        _ = navigator.ShouldNotBeNull();
    }
}