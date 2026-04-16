namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents an argument expression used in generated C# member invocations.
    /// </summary>
    public partial class Argument
    {
        /// <summary>
        /// Defines formatting and naming options used when rendering arguments.
        /// </summary>
        public partial class Options
        {
            /// <summary>
            /// Represents the argument formatting strategy used during snippet generation.
            /// </summary>
            [Monify(Type = typeof(string))]
            [SkipAutoInitialization]
            public sealed partial class Formatters
            {
                /// <summary>
                /// Represents the call for the Formatter.
                /// </summary>
                public static readonly Formatters Call = "{0}: {1}";

                /// <summary>
                /// Represents the declaration for the Formatter.
                /// </summary>
                public static readonly Formatters Declaration = "{0} = {1}";

                private Formatters(string value)
                {
                    _value = value;
                }

                /// <summary>
                /// Gets a value indicating whether the Formatter is call.
                /// </summary>
                /// <value>A value indicating whether the Formatter is call.</value>
                public bool IsCall => this == Call;

                /// <summary>
                /// Gets a value indicating whether the Formatter is declaration.
                /// </summary>
                /// <value>A value indicating whether the Formatter is declaration.</value>
                public bool IsDeclaration => this == Declaration;

                /// <summary>
                /// Defines an implicit conversion from <see cref="Formatters" /> to <see cref="string" />.
                /// </summary>
                /// <param name="formatter">The <see cref="Formatters" /> value to convert.</param>
                /// <returns>The converted <see cref="string" /> value.</returns>
                public static implicit operator string(Formatters formatter)
                {
                    Guard.Against.Conversion<Formatters, string>(formatter);

                    return formatter.ToString();
                }

                /// <summary>
                /// Defines an implicit conversion from <see cref="Formatters" /> to <see cref="Snippet" />.
                /// </summary>
                /// <param name="formatter">The <see cref="Formatters" /> value to convert.</param>
                /// <returns>The converted <see cref="Snippet" /> value.</returns>
                public static implicit operator Snippet(Formatters formatter)
                {
                    Guard.Against.Conversion<Formatters, Snippet>(formatter);

                    return Snippet.From(formatter);
                }

                /// <summary>
                /// Returns the string representation of the Formatter.
                /// </summary>
                /// <returns>The string representation.</returns>
                public override string ToString()
                {
                    return _value;
                }
            }
        }
    }
}