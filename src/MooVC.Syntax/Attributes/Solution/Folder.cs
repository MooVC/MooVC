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
        : IValidatableObject
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
        /// Gets the folders on the Folder.
        /// </summary>
        /// <value>The folders.</value>
        public ImmutableArray<Folder> Folders { get; internal set; } = ImmutableArray<Folder>.Empty;

        /// <summary>
        /// Gets the id on the Folder.
        /// </summary>
        /// <value>The id.</value>
        public Snippet Id { get; internal set; } = Snippet.Empty;

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
        public Snippet Name { get; internal set; } = Snippet.Empty;

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

            XElement[] files = Files
                .Where(file => !file.IsUndefined)
                .SelectMany(file => file.ToFragments())
                .ToArray();

            XElement[] folders = Folders
                .Where(folder => !folder.IsUndefined)
                .SelectMany(folder => folder.ToFragments())
                .ToArray();

            XElement[] items = Items
                .Where(item => !item.IsUndefined)
                .SelectMany(item => item.ToFragments())
                .ToArray();

            return ImmutableArray.Create(new XElement(
                nameof(Folder),
                Id.ToXmlAttribute(nameof(Id))
                .And(Name.ToXmlAttribute(nameof(Name)))
                .And(files)
                .And(folders)
                .And(items)));
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
                .AndIf(!Folders.IsDefaultOrEmpty, nameof(Folders), folder => !folder.IsUndefined, Folders)
                .And(nameof(Id), _ => !Id.IsMultiLine, Id)
                .AndIf(!Items.IsDefaultOrEmpty, nameof(Items), item => !item.IsUndefined, Items)
                .And(nameof(Name), _ => Name.IsSingleLine, Name)
                .Results;
        }
    }
}