namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a C# attribute usage that can be attached to declarations.
    /// </summary>
    public partial class Attribute
    {
        /// <summary>
        /// Represents a target specifier that controls where an attribute is emitted.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Specifiers
        {
            /// <summary>
            /// Represents the assembly for the Specifier.
            /// </summary>
            public static readonly Specifiers Assembly = "assembly";

            /// <summary>
            /// Represents the class for the Specifier.
            /// </summary>
            public static readonly Specifiers Class = "class";

            /// <summary>
            /// Represents the constructor for the Specifier.
            /// </summary>
            public static readonly Specifiers Constructor = "constructor";

            /// <summary>
            /// Represents the delegate for the Specifier.
            /// </summary>
            public static readonly Specifiers Delegate = "delegate";

            /// <summary>
            /// Represents the enum for the Specifier.
            /// </summary>
            public static readonly Specifiers Enum = "enum";

            /// <summary>
            /// Represents the event for the Specifier.
            /// </summary>
            public static readonly Specifiers Event = "event";

            /// <summary>
            /// Represents the field for the Specifier.
            /// </summary>
            public static readonly Specifiers Field = "field";

            /// <summary>
            /// Represents the interface for the Specifier.
            /// </summary>
            public static readonly Specifiers Interface = "interface";

            /// <summary>
            /// Represents the method for the Specifier.
            /// </summary>
            public static readonly Specifiers Method = "method";

            /// <summary>
            /// Represents the module for the Specifier.
            /// </summary>
            public static readonly Specifiers Module = "module";

            /// <summary>
            /// Gets the absence of a value.
            /// </summary>
            public static readonly Specifiers None = string.Empty;

            /// <summary>
            /// Represents the param for the Specifier.
            /// </summary>
            public static readonly Specifiers Param = "param";

            /// <summary>
            /// Represents the property for the Specifier.
            /// </summary>
            public static readonly Specifiers Property = "property";

            /// <summary>
            /// Represents the record for the Specifier.
            /// </summary>
            public static readonly Specifiers Record = "record";

            /// <summary>
            /// Represents the return for the Specifier.
            /// </summary>
            public static readonly Specifiers Return = "return";

            /// <summary>
            /// Represents the struct for the Specifier.
            /// </summary>
            public static readonly Specifiers Struct = "struct";

            /// <summary>
            /// Represents the type for the Specifier.
            /// </summary>
            public static readonly Specifiers Type = "type";

            /// <summary>
            /// Represents the typevar for the Specifier.
            /// </summary>
            public static readonly Specifiers Typevar = "typevar";

            private Specifiers(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Defines the string operator for the Specifier.
            /// </summary>
            /// <param name="specifiers">The specifier.</param>
            /// <returns>The string.</returns>
            public static implicit operator string(Specifiers specifiers)
            {
                Guard.Against.Conversion<Specifiers, string>(specifiers);

                return specifiers.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Specifier.
            /// </summary>
            /// <param name="specifiers">The specifier.</param>
            /// <returns>The snippet.</returns>
            public static implicit operator Snippet(Specifiers specifiers)
            {
                Guard.Against.Conversion<Specifiers, Snippet>(specifiers);

                return Snippet.From(specifiers);
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