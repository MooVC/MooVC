namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a C# member syntax attribute.
    /// </summary>
    public partial class Attribute
    {
        /// <summary>
        /// Represents a C# member syntax specifier.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Specifier
        {
            /// <summary>
            /// Represents the assembly for the Specifier.
            /// </summary>
            public static readonly Specifier Assembly = "assembly";

            /// <summary>
            /// Represents the class for the Specifier.
            /// </summary>
            public static readonly Specifier Class = "class";

            /// <summary>
            /// Represents the constructor for the Specifier.
            /// </summary>
            public static readonly Specifier Constructor = "constructor";

            /// <summary>
            /// Represents the delegate for the Specifier.
            /// </summary>
            public static readonly Specifier Delegate = "delegate";

            /// <summary>
            /// Represents the enum for the Specifier.
            /// </summary>
            public static readonly Specifier Enum = "enum";

            /// <summary>
            /// Represents the event for the Specifier.
            /// </summary>
            public static readonly Specifier Event = "event";

            /// <summary>
            /// Represents the field for the Specifier.
            /// </summary>
            public static readonly Specifier Field = "field";

            /// <summary>
            /// Represents the interface for the Specifier.
            /// </summary>
            public static readonly Specifier Interface = "interface";

            /// <summary>
            /// Represents the method for the Specifier.
            /// </summary>
            public static readonly Specifier Method = "method";

            /// <summary>
            /// Represents the module for the Specifier.
            /// </summary>
            public static readonly Specifier Module = "module";

            /// <summary>
            /// Gets the absence of a value.
            /// </summary>
            public static readonly Specifier None = string.Empty;

            /// <summary>
            /// Represents the param for the Specifier.
            /// </summary>
            public static readonly Specifier Param = "param";

            /// <summary>
            /// Represents the property for the Specifier.
            /// </summary>
            public static readonly Specifier Property = "property";

            /// <summary>
            /// Represents the record for the Specifier.
            /// </summary>
            public static readonly Specifier Record = "record";

            /// <summary>
            /// Represents the return for the Specifier.
            /// </summary>
            public static readonly Specifier Return = "return";

            /// <summary>
            /// Represents the struct for the Specifier.
            /// </summary>
            public static readonly Specifier Struct = "struct";

            /// <summary>
            /// Represents the type for the Specifier.
            /// </summary>
            public static readonly Specifier Type = "type";

            /// <summary>
            /// Represents the typevar for the Specifier.
            /// </summary>
            public static readonly Specifier Typevar = "typevar";

            private Specifier(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Defines the string operator for the Specifier.
            /// </summary>
            /// <param name="specifier">The specifier.</param>
            /// <returns>The string.</returns>
            public static implicit operator string(Specifier specifier)
            {
                Guard.Against.Conversion<Specifier, string>(specifier);

                return specifier.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Specifier.
            /// </summary>
            /// <param name="specifier">The specifier.</param>
            /// <returns>The snippet.</returns>
            public static implicit operator Snippet(Specifier specifier)
            {
                Guard.Against.Conversion<Specifier, Snippet>(specifier);

                return Snippet.From(specifier);
            }

            /// <summary>
            /// Returns the string representation of the Specifier.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}