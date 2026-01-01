namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a C# generic syntax new.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class New
    {
        /// <summary>
        /// Represents the required for the New.
        /// </summary>
        public static readonly New Required = "new()";
        /// <summary>
        /// Represents the not required for the New.
        /// </summary>
        public static readonly New NotRequired = string.Empty;

        private New(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the New is required.
        /// </summary>
        /// <value>A value indicating whether the New is required.</value>
        public bool IsRequired => this == Required;

        /// <summary>
        /// Gets a value indicating whether the New is not required.
        /// </summary>
        /// <value>A value indicating whether the New is not required.</value>
        public bool IsNotRequired => this == NotRequired;

        /// <summary>
        /// Defines the string operator for the New.
        /// </summary>
        /// <param name="@new">The new.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(New @new)
        {
            Guard.Against.Conversion<New, string>(@new);

            return @new.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the New.
        /// </summary>
        /// <param name="@new">The new.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(New @new)
        {
            Guard.Against.Conversion<New, Snippet>(@new);

            return Snippet.From(@new);
        }

        /// <summary>
        /// Returns the string representation of the New.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value;
        }
    }
}