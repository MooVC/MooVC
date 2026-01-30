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
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Resource
        : Construct
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Resource Undefined = new Resource();

        /// <summary>
        /// Gets the assemblies on the Resource.
        /// </summary>
        /// <value>The assemblies.</value>
        public ImmutableArray<Assembly> Assemblies { get; internal set; } = ImmutableArray<Assembly>.Empty;

        /// <summary>
        /// Gets the data on the Resource.
        /// </summary>
        /// <value>The data.</value>
        public ImmutableArray<Data> Data { get; internal set; } = ImmutableArray<Data>.Empty;

        /// <summary>
        /// Gets the headers on the Resource.
        /// </summary>
        /// <value>The headers.</value>
        public ImmutableArray<Header> Headers { get; internal set; } = ImmutableArray<Header>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Resource is undefined.
        /// </summary>
        /// <value>A value indicating whether the Resource is undefined.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the metadata on the Resource.
        /// </summary>
        /// <value>The metadata.</value>
        public ImmutableArray<Metadata> Metadata { get; internal set; } = ImmutableArray<Metadata>.Empty;

        /// <summary>
        /// Creates an XML document for the Resource.
        /// </summary>
        /// <returns>The generated XML document.</returns>
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
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToDocument().ToString();
        }

        /// <summary>
        /// Validates the Resource.
        /// </summary>
        /// <remarks>Required members include: Assemblies, Data, Metadata, Headers.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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