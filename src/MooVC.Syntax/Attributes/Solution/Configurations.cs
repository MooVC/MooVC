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
    using static MooVC.Syntax.Attributes.Solution.Configurations;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a MSBuild solution attribute configuration.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Configurations
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Configurations Default = new Configurations();

        /// <summary>
        /// Initializes a new instance of the Configuration class.
        /// </summary>
        internal Configurations()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Configuration is undefined.
        /// </summary>
        /// <value>A value indicating whether the Configuration is undefined.</value>
        [Ignore]
        public bool IsDefault => this == Default;

        /// <summary>
        /// Gets the name on the Configuration.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public ImmutableArray<BuildType> Builds { get; internal set; } = ImmutableArray.Create(BuildType.Debug, BuildType.Release);

        /// <summary>
        /// Gets the platform on the Configuration.
        /// </summary>
        /// <value>The platform.</value>
        [Descriptor("For")]
        public ImmutableArray<Platform> Platforms { get; internal set; } = ImmutableArray.Create(Platform.AnyCPU);

        /// <summary>
        /// Performs the to fragments operation for the MSBuild solution attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsDefault)
            {
                return ImmutableArray<XElement>.Empty;
            }

            XElement[] builds = Builds
                .Where(build => !build.IsUnnamed)
                .SelectMany(build => build.ToFragments())
                .ToArray();

            XElement[] platforms = Platforms
                .Where(platform => !platform.IsUnspecified)
                .SelectMany(platform => platform.ToFragments())
                .ToArray();

            return ImmutableArray.Create(new XElement(nameof(Configurations), builds.Concat(platforms)));
        }

        /// <summary>
        /// Returns the string representation of the Configuration.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsDefault)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Configuration.
        /// </summary>
        /// <remarks>Required members include: Name, Platform.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsDefault)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Builds.IsDefaultOrEmpty, nameof(Builds), Builds)
                .AndIf(!Platforms.IsDefaultOrEmpty, nameof(Platforms), Platforms)
                .Results;
        }
    }
}