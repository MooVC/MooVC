namespace MooVC.Syntax.Concepts
{
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

    /// <summary>
    /// Represents a syntax construct resource.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Resource
        : Construct
    {
        /// <summary>
        /// Gets the undefined on the Resource.
        /// </summary>
        public static readonly Resource Undefined = new Resource();

        /// <summary>
        /// Gets or sets the assemblies on the Resource.
        /// </summary>
        public ImmutableArray<Assembly> Assemblies { get; internal set; } = ImmutableArray<Assembly>.Empty;

        /// <summary>
        /// Gets or sets the data on the Resource.
        /// </summary>
        public ImmutableArray<Data> Data { get; internal set; } = ImmutableArray<Data>.Empty;

        /// <summary>
        /// Gets or sets the headers on the Resource.
        /// </summary>
        public ImmutableArray<Header> Headers { get; internal set; } = ImmutableArray<Header>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Resource is undefined.
        /// </summary>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the metadata on the Resource.
        /// </summary>
        public ImmutableArray<Metadata> Metadata { get; internal set; } = ImmutableArray<Metadata>.Empty;

        /// <summary>
        /// Creates an XML document for the Resource.
        /// </summary>
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

        /// <summary>
        /// Returns the string representation of the Resource.
        /// </summary>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToDocument().ToString();
        }

        /// <summary>
        /// Validates the Resource and returns validation results.
        /// </summary>
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
}