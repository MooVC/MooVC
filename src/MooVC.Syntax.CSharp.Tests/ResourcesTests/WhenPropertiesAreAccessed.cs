namespace MooVC.Syntax.CSharp.ResourcesTests;

using System.Globalization;
using System.Reflection;
using System.Resources;
using ReflectionType = System.Type;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public async Task GivenGeneratedResourceTypesThenAllResourcesCanBeRead()
    {
        // Arrange
        ReflectionType[] resourceTypes = typeof(Options).Assembly
            .GetTypes()
            .Where(IsGeneratedResourceType)
            .OrderBy(type => type.FullName)
            .ToArray();

        // Act
        int resources = resourceTypes.Sum(ReadResources);

        // Assert
        _ = await Assert.That(resourceTypes).IsNotEmpty();
        _ = await Assert.That(resources).IsGreaterThan(0);
    }

    private static bool IsGeneratedResourceType(ReflectionType type)
    {
        return type.Name.EndsWith("_Resources", StringComparison.Ordinal);
    }

    private static int ReadResources(ReflectionType resourceType)
    {
        _ = Activator.CreateInstance(resourceType, nonPublic: true);

        FieldInfo? resourceManagerField = resourceType.GetField("resourceMan", BindingFlags.NonPublic | BindingFlags.Static);

        resourceManagerField?.SetValue(null, null);

        PropertyInfo resourceManagerProperty = GetProperty(resourceType, "ResourceManager");
        ResourceManager? first = resourceManagerProperty.GetValue(null) as ResourceManager;
        ResourceManager? second = resourceManagerProperty.GetValue(null) as ResourceManager;

        if (first is null || second is null)
        {
            return 0;
        }

        PropertyInfo cultureProperty = GetProperty(resourceType, "Culture");

        cultureProperty.SetValue(null, CultureInfo.InvariantCulture);
        _ = cultureProperty.GetValue(null);
        cultureProperty.SetValue(null, null);

        return resourceType
            .GetProperties(BindingFlags.NonPublic | BindingFlags.Static)
            .Where(property => property.PropertyType == typeof(string))
            .Select(property => property.GetValue(null))
            .OfType<string>()
            .Count();
    }

    private static PropertyInfo GetProperty(ReflectionType resourceType, string name)
    {
        return resourceType.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Static)!;
    }
}