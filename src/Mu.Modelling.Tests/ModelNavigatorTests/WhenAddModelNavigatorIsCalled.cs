namespace Mu.Modelling.ModelNavigatorTests;

using System;
using System.Linq;
using System.Reflection;
using Graphify;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenAddModelNavigatorIsCalled
{
    private const string AddModelNavigatorName = "AddModelNavigator";
    private const string NavigatorTypeName = "Mu.Modelling.ModelNavigator";

    [Fact]
    public void GivenServicesThenNavigatorIsRegistered()
    {
        // Arrange
        ServiceCollection services = new();
        Type assemblyType = typeof(Model);
        MethodInfo? method = assemblyType.Assembly
            .GetTypes()
            .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            .SingleOrDefault(candidate => candidate.Name == AddModelNavigatorName
                && candidate.GetParameters().Length == 1
                && typeof(IServiceCollection).IsAssignableFrom(candidate.GetParameters()[0].ParameterType));

        // Act
        _ = method.ShouldNotBeNull();
        _ = method!.Invoke(null, new object?[] { services });
        using ServiceProvider provider = services.BuildServiceProvider();
        INavigator<Model> navigator = provider.GetRequiredService<INavigator<Model>>();
        Type? navigatorType = assemblyType.Assembly.GetType(NavigatorTypeName);

        // Assert
        navigatorType.ShouldNotBeNull();
        navigator.GetType().ShouldBe(navigatorType);
    }
}