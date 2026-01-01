namespace MooVC.Syntax.Attributes.Resource;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using Fluentify;
using MooVC.Syntax;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Validation;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Valuify]
public sealed partial class Metadata
    : IValidatableObject
{
    public static readonly Metadata Undefined = new Metadata();

    internal Metadata()
    {
    }

    [Ignore]
    public bool IsUndefined => this == Undefined;

    public Snippet MimeType { get; internal set; } = Snippet.Empty;

    public Snippet Name { get; internal set; } = Snippet.Empty;

    public Snippet Type { get; internal set; } = Snippet.Empty;

    public Snippet Value { get; internal set; } = Snippet.Empty;

    public Snippet XmlSpace { get; internal set; } = Snippet.Empty;

    public ImmutableArray<XElement> ToFragments()
    {
        if (IsUndefined)
        {
            return ImmutableArray<XElement>.Empty;
        }

        var builder = ImmutableArray.CreateBuilder<XElement>(1);

        builder.Add(new XElement(
            "metadata",
            Name.ToXmlAttribute("name"),
            Type.ToXmlAttribute("type"),
            MimeType.ToXmlAttribute("mimetype"),
            ToXmlSpaceAttribute(XmlSpace),
            new XElement("value", Value.ToString())));

        return builder.ToImmutable();
    }

    public override string ToString()
    {
        if (IsUndefined)
        {
            return string.Empty;
        }

        return ToFragments().Merge();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .Include(nameof(MimeType), _ => !MimeType.IsMultiLine, MimeType)
            .And(nameof(Name), _ => !Name.IsMultiLine, Name)
            .And(nameof(Type), _ => !Type.IsMultiLine, Type)
            .And(nameof(XmlSpace), _ => !XmlSpace.IsMultiLine, XmlSpace)
            .Results;
    }

    private static XAttribute ToXmlSpaceAttribute(Snippet xmlSpace)
    {
        if (xmlSpace.IsEmpty)
        {
            return null;
        }

        return new XAttribute(XNamespace.Xml + "space", xmlSpace.ToString());
    }
}