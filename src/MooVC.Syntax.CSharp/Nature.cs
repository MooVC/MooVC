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
        /// Defines an implicit conversion from <see cref="Natures" /> to <see cref="string" />.
        /// </summary>
        /// <param name="nature">The <see cref="Natures" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Natures nature)
        {
            Guard.Against.Conversion<Natures, string>(nature);

            return nature.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Natures" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="nature">The <see cref="Natures" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
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