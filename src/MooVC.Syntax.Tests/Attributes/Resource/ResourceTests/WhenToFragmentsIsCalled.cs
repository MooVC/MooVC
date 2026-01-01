namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using System.Collections.Immutable;
using System.Xml.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Resource subject = Resource.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenLocationThenReturnsCompileAndEmbeddedResource()
    {
        // Arrange
        var location = new Path(ResourceTestsData.DefaultLocationPath);
        Resource subject = new Resource { Location = location };
        Path designer = location.ChangeExtension("Designer.cs");

        var expectedCompile = new XElement(
            "Compile",
            new XAttribute("Update", designer.ToString()),
            new XElement("DesignTime", "True"),
            new XElement("AutoGen", "True"),
            new XElement("DependentUpon", location.FileName));

        var expectedEmbeddedResource = new XElement(
            "EmbeddedResource",
            new XAttribute("Update", location.ToString()),
            new XElement("Generator", "ResXFileCodeGenerator"),
            new XElement("LastGenOutput", designer.FileName));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.Length.ShouldBe(2);
        XNode.DeepEquals(expectedCompile, result[0]).ShouldBeTrue();
        XNode.DeepEquals(expectedEmbeddedResource, result[1]).ShouldBeTrue();
    }

    [Fact]
    public void GivenPublicResourceWithNamespaceThenReturnsCustomToolNamespace()
    {
        // Arrange
        Snippet customToolNamespace = Snippet.From(ResourceTestsData.DefaultCustomToolNamespace);
        var location = new Path(ResourceTestsData.DefaultLocationPath);
        var designer = new Path(ResourceTestsData.DefaultDesignerPath);
        Resource subject = new Resource
        {
            CustomToolNamespace = customToolNamespace,
            Designer = designer,
            Location = location,
            Visibility = Resource.Scope.Public,
        };

        var expectedCompile = new XElement(
            "Compile",
            new XAttribute("Update", designer.ToString()),
            new XElement("DesignTime", "True"),
            new XElement("AutoGen", "True"),
            new XElement("DependentUpon", location.FileName));

        var expectedEmbeddedResource = new XElement(
            "EmbeddedResource",
            new XAttribute("Update", location.ToString()),
            new XElement("Generator", "PublicResXFileCodeGenerator"),
            new XElement("LastGenOutput", designer.FileName),
            new XElement("CustomToolNamespace", customToolNamespace.ToString()));

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.Length.ShouldBe(2);
        XNode.DeepEquals(expectedCompile, result[0]).ShouldBeTrue();
        XNode.DeepEquals(expectedEmbeddedResource, result[1]).ShouldBeTrue();
    }
}