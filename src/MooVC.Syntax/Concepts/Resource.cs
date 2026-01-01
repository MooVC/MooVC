namespace MooVC.Syntax.Concepts;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using Fluentify;
using MooVC.Syntax.Attributes.Resource;
using MooVC.Syntax.Validation;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Valuify]
public sealed partial class Resource
    : Construct
{
    public static readonly Resource Undefined = new Resource();

    public ImmutableArray<Assembly> Assemblies { get; internal set; } = ImmutableArray<Assembly>.Empty;

    public ImmutableArray<Data> Data { get; internal set; } = ImmutableArray<Data>.Empty;

    public ImmutableArray<Header> Headers { get; internal set; } = ImmutableArray<Header>.Empty;

    public ImmutableArray<Metadata> Metadata { get; internal set; } = ImmutableArray<Metadata>.Empty;

    [Ignore]
    public override bool IsUndefined => this == Undefined;

    public XDocument ToDocument()
    {
        if (IsUndefined)
        {
            return new XDocument();
        }

        XElement[] headers = Headers
            .Where(header => !header.IsUndefined)
            .SelectMany(header => header.ToFragments())
            .ToArray();

        XElement[] assemblies = Assemblies
            .Where(assembly => !assembly.IsUndefined)
            .SelectMany(assembly => assembly.ToFragments())
            .ToArray();

        XElement[] data = Data
            .Where(entry => !entry.IsUndefined)
            .SelectMany(entry => entry.ToFragments())
            .ToArray();

        XElement[] metadata = Metadata
            .Where(entry => !entry.IsUndefined)
            .SelectMany(entry => entry.ToFragments())
            .ToArray();

        var declaration = new XDeclaration("1.0", "utf-8", "yes");
        var root = new XElement("root", headers, assemblies, data, metadata);

        return new XDocument(declaration, root);
    }

    public override string ToString()
    {
        if (IsUndefined)
        {
            return string.Empty;
        }

        return ToDocument().ToString();
    }

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Array.Empty<ValidationResult>();
        }

        return validationContext
            .IncludeIf(!Assemblies.IsDefaultOrEmpty, nameof(Assemblies), assembly => !assembly.IsUndefined, Assemblies)
            .AndIf(!Data.IsDefaultOrEmpty, nameof(Data), entry => !entry.IsUndefined, Data)
            .AndIf(!Metadata.IsDefaultOrEmpty, nameof(Metadata), entry => !entry.IsUndefined, Metadata)
            .AndIf(!Headers.IsDefaultOrEmpty, nameof(Headers), header => !header.IsUndefined, Headers)
            .Results;
    }
}