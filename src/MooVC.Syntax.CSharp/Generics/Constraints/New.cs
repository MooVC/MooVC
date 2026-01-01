namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a c# generic syntax new.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class New
    {
        /// <summary>
        /// Gets the required on the New.
        /// </summary>
        public static readonly New Required = "new()";
        /// <summary>
        /// Gets the not required on the New.
        /// </summary>
        public static readonly New NotRequired = string.Empty;

        private New(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the New is required.
        /// </summary>
        public bool IsRequired => this == Required;

        /// <summary>
        /// Gets a value indicating whether the New is not required.
        /// </summary>
        public bool IsNotRequired => this == NotRequired;

        /// <summary>
        /// Defines the string operator for the New.
        /// </summary>
        public static implicit operator string(New @new)
        {
            Guard.Against.Conversion<New, string>(@new);

            return @new.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the New.
        /// </summary>
        public static implicit operator Snippet(New @new)
        {
            Guard.Against.Conversion<New, Snippet>(@new);

            return Snippet.From(@new);
        }

        /// <summary>
        /// Returns the string representation of the New.
        /// </summary>
        public override string ToString()
        {
            return _value;
        }
    }
}