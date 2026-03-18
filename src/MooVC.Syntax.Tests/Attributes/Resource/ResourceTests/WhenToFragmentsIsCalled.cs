namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using System.Collections.Immutable;
using System.Xml.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenToFragmentsIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Resource subject = Resource.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenLocationThenReturnsCompileAndEmbeddedResource()
    {
        // Arrange
        var location = new Path(ResourceTestsData.DefaultLocationPath);
        var subject = new Resource { Location = location };
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
        await Assert.That(result.Length).IsEqualTo(2);
        await Assert.That(XNode.DeepEquals(expectedCompile, result[0])).IsTrue();
        await Assert.That(XNode.DeepEquals(expectedEmbeddedResource, result[1])).IsTrue();
    }

    [Test]
    public async Task GivenPublicResourceWithNamespaceThenReturnsCustomToolNamespace()
    {
        // Arrange
        var customToolNamespace = Snippet.From(ResourceTestsData.DefaultCustomToolNamespace);
        var location = new Path(ResourceTestsData.DefaultLocationPath);
        var designer = new Path(ResourceTestsData.DefaultDesignerPath);
        var subject = new Resource
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
        await Assert.That(result.Length).IsEqualTo(2);
        await Assert.That(XNode.DeepEquals(expectedCompile, result[0])).IsTrue();
        await Assert.That(XNode.DeepEquals(expectedEmbeddedResource, result[1])).IsTrue();
    }
}