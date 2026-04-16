namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents the `new()` constructor constraint in generic clauses.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
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
        /// Defines an implicit conversion from <see cref="New" /> to <see cref="string" />.
        /// </summary>
        /// <param name="@new">The <see cref="New" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(New @new)
        {
            Guard.Against.Conversion<New, string>(@new);

            return @new.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="New" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="@new">The <see cref="New" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(New @new)
        {
            Guard.Against.Conversion<New, Snippet>(@new);

            return Snippet.From(@new.ToString());
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