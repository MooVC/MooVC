namespace MooVC.Syntax.Concepts.ProjectTests;

using MooVC.Syntax.Attributes.Project;
using Resource = MooVC.Syntax.Attributes.Resource.Resource;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenProjectIsUndefined()
    {
        // Act
        var subject = new Project();

        // Assert
        _ = await Assert.That(subject.Imports).IsEmpty();
        _ = await Assert.That(subject.ItemGroups).IsEmpty();
        _ = await Assert.That(subject.PropertyGroups).IsEmpty();
        _ = await Assert.That(subject.Resources).IsEmpty();
        _ = await Assert.That(subject.Sdks).IsEmpty();
        _ = await Assert.That(subject.Targets).IsEmpty();
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Import import = ProjectTestsData.CreateImport();
        ItemGroup itemGroup = ProjectTestsData.CreateItemGroup();
        PropertyGroup propertyGroup = ProjectTestsData.CreatePropertyGroup();
        Resource resource = ProjectTestsData.CreateResource();
        Sdk sdk = ProjectTestsData.CreateSdk();
        Target target = ProjectTestsData.CreateTarget();

        // Act
        var subject = new Project
        {
            Imports = [import],
            ItemGroups = [itemGroup],
            PropertyGroups = [propertyGroup],
            Resources = [resource],
            Sdks = [sdk],
            Targets = [target],
        };

        // Assert
        _ = await Assert.That(subject.Imports).IsEqualTo(new[] { import });
        _ = await Assert.That(subject.ItemGroups).IsEqualTo(new[] { itemGroup });
        _ = await Assert.That(subject.PropertyGroups).IsEqualTo(new[] { propertyGroup });
        _ = await Assert.That(subject.Resources).IsEqualTo(new[] { resource });
        _ = await Assert.That(subject.Sdks).IsEqualTo(new[] { sdk });
        _ = await Assert.That(subject.Targets).IsEqualTo(new[] { target });
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}