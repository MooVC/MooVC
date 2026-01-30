namespace MooVC.Syntax.Attributes.Solution
{
    using System;
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

    /// <summary>
    /// Represents a MSBuild solution attribute project.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Project
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Project Undefined = new Project();

        /// <summary>
        /// Initializes a new instance of the Project class.
        /// </summary>
        internal Project()
        {
        }

        /// <summary>
        /// Gets the id on the Project.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; internal set; } = Guid.Empty;

        /// <summary>
        /// Gets a value indicating whether the Project is undefined.
        /// </summary>
        /// <value>A value indicating whether the Project is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the collection of supported builds for the current context.
        /// </summary>
        /// <value>
        /// The collection of supported builds for the current context.
        /// </value>
        public ImmutableArray<Build> Builds { get; internal set; } = ImmutableArray<Build>.Empty;

        /// <summary>
        /// Gets the name on the Project.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Name DisplayName { get; internal set; } = Name.Unnamed;

        /// <summary>
        /// Gets the path on the Project.
        /// </summary>
        /// <value>The path.</value>
        [Descriptor("At")]
        public RelativePath Path { get; internal set; } = RelativePath.Unspecified;

        /// <summary>
        /// Gets the collection of supported platforms for the current context.
        /// </summary>
        /// <value>
        /// The collection of supported platforms for the current context.
        /// </value>
        public ImmutableArray<Platform> Platforms { get; internal set; } = ImmutableArray<Platform>.Empty;

        /// <summary>
        /// Gets the type on the Project.
        /// </summary>
        /// <value>The type.</value>
        [Descriptor("OfType")]
        public Snippet Type { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the to fragments operation for the MSBuild solution attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement> builds = Builds.Get(build => !build.IsUndefined);
            ImmutableArray<XElement> platforms = Platforms.Get(platform => !platform.IsUndefined);

            return ImmutableArray.Create(new XElement(
                nameof(Project),
                builds
                .And(DisplayName.ToXmlAttribute(nameof(DisplayName), include: _ => !DisplayName.IsUnnamed))
                .And(Id.ToXmlAttribute(nameof(Id), include: _ => Id != Guid.Empty))
                .And(Path.ToXmlAttribute(nameof(Path)))
                .And(platforms)
                .And(Type.ToXmlAttribute(nameof(Type), include: _ => Type.IsSingleLine))));
        }

        /// <summary>
        /// Returns the string representation of the Project.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Project.
        /// </summary>
        /// <remarks>Required members include: Id, Name, Path, Type.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Builds.IsDefaultOrEmpty, nameof(Builds), build => !build.IsUndefined, Builds)
                .And(nameof(DisplayName), _ => !DisplayName.IsUnnamed, DisplayName)
                .And(nameof(Path), _ => !Path.IsUnspecified, Path)
                .AndIf(!Platforms.IsDefaultOrEmpty, nameof(Platforms), platform => !platform.IsUndefined, Platforms)
                .And(nameof(Type), _ => !Type.IsMultiLine, Type)
                .Results;
        }
    }
}