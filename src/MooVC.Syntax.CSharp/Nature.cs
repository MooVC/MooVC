namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents class/struct constraints applied to generic type parameters.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Natures
    {
        /// <summary>
        /// Represents the class for the Nature.
        /// </summary>
        public static readonly Natures Class = "class";

        /// <summary>
        /// Represents the struct for the Nature.
        /// </summary>
        public static readonly Natures Struct = "struct";

        /// <summary>
        /// Represents the unmanaged for the Nature.
        /// </summary>
        public static readonly Natures Unmanaged = "unmanaged";

        /// <summary>
        /// Represents the not <see langword="null" /> value for the Nature.
        /// </summary>
        public static readonly Natures NotNull = "notnull";

        /// <summary>
        /// Gets the unspecified instance.
        /// </summary>
        public static readonly Natures Unspecified = string.Empty;

        private Natures(string value)
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
        public static implicit operator string(Natures nature)
        {
            Guard.Against.Conversion<Natures, string>(nature);

            return nature.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Nature.
        /// </summary>
        /// <param name="nature">The nature.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Natures nature)
        {
            Guard.Against.Conversion<Natures, Snippet>(nature);

            return Snippet.From(nature.ToString());
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