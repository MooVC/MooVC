namespace MooVC.Syntax.CSharp.Concepts.ProjectTests;

using System.Xml.Linq;
using MooVC.Syntax.CSharp.Attributes.Project;

public sealed class WhenToDocumentIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmptyDocument()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        result.Root.ShouldBeNull();
        result.Declaration.ShouldBeNull();
    }

    [Fact]
    public void GivenValuesThenReturnsDocument()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();

        var importElement = new XElement(
            nameof(Import),
            new XAttribute(nameof(Import.Project), ProjectTestsData.DefaultImportProject));

        var itemElement = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Include), ProjectTestsData.DefaultItemInclude));

        var itemGroupElement = new XElement(nameof(ItemGroup), itemElement);

        var propertyElement = new XElement(
            ProjectTestsData.DefaultPropertyName,
            ProjectTestsData.DefaultPropertyValue);

        var propertyGroupElement = new XElement(nameof(PropertyGroup), propertyElement);

        var sdkElement = new XElement(
            nameof(Sdk),
            new XAttribute(nameof(Sdk.Name), ProjectTestsData.DefaultSdkName.ToString()),
            new XAttribute(nameof(Sdk.Version), ProjectTestsData.DefaultSdkVersion));

        var targetElement = new XElement(
            nameof(Target),
            new XAttribute(nameof(Target.Name), ProjectTestsData.DefaultTargetName));

        var expected = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement(
                nameof(Project),
                importElement,
                itemGroupElement,
                propertyGroupElement,
                sdkElement,
                targetElement));

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        result.Declaration.ShouldNotBeNull();
        result.Declaration!.Version.ShouldBe("1.0");
        result.Declaration.Encoding.ShouldBe("utf-8");
        result.Declaration.Standalone.ShouldBe("yes");
        XNode.DeepEquals(expected, result).ShouldBeTrue();
    }
}