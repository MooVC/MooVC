namespace MooVC.Syntax.CSharp.Concepts.ProjectTests;

using MooVC.Syntax.CSharp.Attributes.Project;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenProjectIsUndefined()
    {
        // Act
        var subject = new Project();

        // Assert
        subject.Imports.ShouldBeEmpty();
        subject.ItemGroups.ShouldBeEmpty();
        subject.PropertyGroups.ShouldBeEmpty();
        subject.Sdks.ShouldBeEmpty();
        subject.Targets.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Import import = ProjectTestsData.CreateImport();
        ItemGroup itemGroup = ProjectTestsData.CreateItemGroup();
        PropertyGroup propertyGroup = ProjectTestsData.CreatePropertyGroup();
        Sdk sdk = ProjectTestsData.CreateSdk();
        Target target = ProjectTestsData.CreateTarget();

        // Act
        var subject = new Project
        {
            Imports = [import],
            ItemGroups = [itemGroup],
            PropertyGroups = [propertyGroup],
            Sdks = [sdk],
            Targets = [target],
        };

        // Assert
        subject.Imports.ShouldBe(new[] { import });
        subject.ItemGroups.ShouldBe(new[] { itemGroup });
        subject.PropertyGroups.ShouldBe(new[] { propertyGroup });
        subject.Sdks.ShouldBe(new[] { sdk });
        subject.Targets.ShouldBe(new[] { target });
        subject.IsUndefined.ShouldBeFalse();
    }
}