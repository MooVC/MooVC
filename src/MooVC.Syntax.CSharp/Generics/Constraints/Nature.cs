namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a c# generic syntax nature.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Nature
    {
        /// <summary>
        /// Gets the class on the Nature.
        /// </summary>
        public static readonly Nature Class = "class";
        /// <summary>
        /// Gets the struct on the Nature.
        /// </summary>
        public static readonly Nature Struct = "struct";
        /// <summary>
        /// Gets the unmanaged on the Nature.
        /// </summary>
        public static readonly Nature Unmanaged = "unmanaged";
        /// <summary>
        /// Gets the not null on the Nature.
        /// </summary>
        public static readonly Nature NotNull = "notnull";
        /// <summary>
        /// Gets the unspecified on the Nature.
        /// </summary>
        public static readonly Nature Unspecified = string.Empty;

        private Nature(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the Nature is unspecified.
        /// </summary>
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Defines the string operator for the Nature.
        /// </summary>
        public static implicit operator string(Nature nature)
        {
            Guard.Against.Conversion<Nature, string>(nature);

            return nature.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Nature.
        /// </summary>
        public static implicit operator Snippet(Nature nature)
        {
            Guard.Against.Conversion<Nature, Snippet>(nature);

            return Snippet.From(nature);
        }

        /// <summary>
        /// Returns the string representation of the Nature.
        /// </summary>
        public override string ToString()
        {
            return _value;
        }
    }
}