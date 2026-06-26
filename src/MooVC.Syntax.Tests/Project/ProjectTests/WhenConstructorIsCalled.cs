namespace MooVC.Syntax.Project.ProjectTests;

using Item = MooVC.Syntax.Resource.Item;

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
        Item resource = ProjectTestsData.CreateResource();
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
        _ = await Assert.That(subject.Imports).IsEquivalentTo([import]);
        _ = await Assert.That(subject.ItemGroups).IsEquivalentTo([itemGroup]);
        _ = await Assert.That(subject.PropertyGroups).IsEquivalentTo([propertyGroup]);
        _ = await Assert.That(subject.Resources).IsEquivalentTo([resource]);
        _ = await Assert.That(subject.Sdks).IsEquivalentTo([sdk]);
        _ = await Assert.That(subject.Targets).IsEquivalentTo([target]);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}