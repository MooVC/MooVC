namespace MooVC.Syntax.Concepts.ProjectTests;

using System.Xml.Linq;
using MooVC.Syntax.Attributes.Project;

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

        var compileElement = new XElement(
            "Compile",
            new XAttribute("Update", ProjectTestsData.DefaultDesignerPath),
            new XElement("DesignTime", "True"),
            new XElement("AutoGen", "True"),
            new XElement("DependentUpon", ProjectTestsData.DefaultLocation));

        var embeddedResourceElement = new XElement(
            "EmbeddedResource",
            new XAttribute("Update", ProjectTestsData.DefaultLocation),
            new XElement("Generator", "ResXFileCodeGenerator"),
            new XElement("LastGenOutput", ProjectTestsData.DefaultDesignerPath),
            new XElement("CustomToolNamespace", ProjectTestsData.DefaultResourceToolNamespace));

        var resourceItemGroupElement = new XElement(nameof(ItemGroup), compileElement, embeddedResourceElement);

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
                propertyGroupElement,
                itemGroupElement,
                resourceItemGroupElement,
                importElement,
                sdkElement,
                targetElement));

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        XDeclaration declaration = result.Declaration.ShouldNotBeNull();
        declaration.Version.ShouldBe("1.0");
        declaration.Encoding.ShouldBe("utf-8");
        declaration.Standalone.ShouldBe("yes");
        XNode.DeepEquals(expected, result).ShouldBeTrue();
    }
}