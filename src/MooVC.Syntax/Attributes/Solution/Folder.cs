namespace MooVC.Syntax.Attributes.Solution
{
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
    /// Represents a MSBuild solution attribute folder.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Folder
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Folder Undefined = new Folder();

        /// <summary>
        /// Initializes a new instance of the Folder class.
        /// </summary>
        internal Folder()
        {
        }

        /// <summary>
        /// Gets the files on the Folder.
        /// </summary>
        /// <value>The files.</value>
        public ImmutableArray<File> Files { get; internal set; } = ImmutableArray<File>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Folder is undefined.
        /// </summary>
        /// <value>A value indicating whether the Folder is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the items on the Folder.
        /// </summary>
        /// <value>The items.</value>
        public ImmutableArray<Item> Items { get; internal set; } = ImmutableArray<Item>.Empty;

        /// <summary>
        /// Gets the name on the Folder.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Path Name { get; internal set; } = Path.Root;

        /// <summary>
        /// Gets the projects on the Folder.
        /// </summary>
        /// <value>The projects.</value>
        public ImmutableArray<Project> Projects { get; internal set; } = ImmutableArray<Project>.Empty;

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

            ImmutableArray<XElement> files = Files.Get(file => !file.IsUndefined);
            ImmutableArray<XElement> items = Items.Get(item => !item.IsUndefined);
            ImmutableArray<XElement> projects = Projects.Get(project => !project.IsUndefined);

            return ImmutableArray.Create(new XElement(
                nameof(Folder),
                Name.ToXmlAttribute(nameof(Name))
                .And(files)
                .And(items)
                .And(projects)));
        }

        /// <summary>
        /// Returns the string representation of the Folder.
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
        /// Validates the Folder.
        /// </summary>
        /// <remarks>Required members include: Files, Folders, Id, Items, Name.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Files.IsDefaultOrEmpty, nameof(Files), file => !file.IsUndefined, Files)
                .AndIf(!Items.IsDefaultOrEmpty, nameof(Items), item => !item.IsUndefined, Items)
                .And(nameof(Name), Name)
                .Results;
        }
    }
}