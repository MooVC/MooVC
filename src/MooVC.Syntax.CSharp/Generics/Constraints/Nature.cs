namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a C# generic syntax nature.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Nature
    {
        /// <summary>
        /// Represents the class for the Nature.
        /// </summary>
        public static readonly Nature Class = "class";

        /// <summary>
        /// Represents the struct for the Nature.
        /// </summary>
        public static readonly Nature Struct = "struct";

        /// <summary>
        /// Represents the unmanaged for the Nature.
        /// </summary>
        public static readonly Nature Unmanaged = "unmanaged";

        /// <summary>
        /// Represents the not null for the Nature.
        /// </summary>
        public static readonly Nature NotNull = "notnull";

        /// <summary>
        /// Gets the unspecified instance.
        /// </summary>
        public static readonly Nature Unspecified = string.Empty;

        private Nature(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the Nature is unspecified.
        /// </summary>
        /// <value>A value indicating whether the Nature is unspecified.</value>
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Defines the string operator for the Nature.
        /// </summary>
        /// <param name="nature">The nature.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Nature nature)
        {
            Guard.Against.Conversion<Nature, string>(nature);

            return nature.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Nature.
        /// </summary>
        /// <param name="nature">The nature.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Nature nature)
        {
            Guard.Against.Conversion<Nature, Snippet>(nature);

            return Snippet.From(nature);
        }

        /// <summary>
        /// Returns the string representation of the Nature.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value;
        }
    }
}