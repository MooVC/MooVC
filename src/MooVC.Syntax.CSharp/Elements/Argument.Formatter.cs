namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a c# syntax element argument.
    /// </summary>
    public partial class Argument
    {
        /// <summary>
        /// Represents a c# syntax element formatter.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Formatter
        {
            /// <summary>
            /// Gets the call on the Formatter.
            /// </summary>
            public static readonly Formatter Call = new Formatter("{0}: {1}");
            /// <summary>
            /// Gets the declaration on the Formatter.
            /// </summary>
            public static readonly Formatter Declaration = new Formatter("{0} = {1}");

            private Formatter(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Formatter is call.
            /// </summary>
            public bool IsCall => this == Call;

            /// <summary>
            /// Gets a value indicating whether the Formatter is declaration.
            /// </summary>
            public bool IsDeclaration => this == Declaration;

            /// <summary>
            /// Defines the string operator for the Formatter.
            /// </summary>
            public static implicit operator string(Formatter formatter)
            {
                Guard.Against.Conversion<Formatter, string>(formatter);

                return formatter.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Formatter.
            /// </summary>
            public static implicit operator Snippet(Formatter formatter)
            {
                Guard.Against.Conversion<Formatter, Snippet>(formatter);

                return Snippet.From(formatter);
            }

            /// <summary>
            /// Returns the string representation of the Formatter.
            /// </summary>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}