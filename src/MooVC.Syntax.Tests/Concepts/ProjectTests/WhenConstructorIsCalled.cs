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
        await Assert.That(subject.Imports).IsEmpty();
        await Assert.That(subject.ItemGroups).IsEmpty();
        await Assert.That(subject.PropertyGroups).IsEmpty();
        await Assert.That(subject.Resources).IsEmpty();
        await Assert.That(subject.Sdks).IsEmpty();
        await Assert.That(subject.Targets).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
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
        await Assert.That(subject.Imports).IsEqualTo(new[] { import });
        await Assert.That(subject.ItemGroups).IsEqualTo(new[] { itemGroup });
        await Assert.That(subject.PropertyGroups).IsEqualTo(new[] { propertyGroup });
        await Assert.That(subject.Resources).IsEqualTo(new[] { resource });
        await Assert.That(subject.Sdks).IsEqualTo(new[] { sdk });
        await Assert.That(subject.Targets).IsEqualTo(new[] { target });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}