namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a c# member syntax attribute.
    /// </summary>
    public partial class Attribute
    {
        /// <summary>
        /// Represents a c# member syntax specifier.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Specifier
        {
            /// <summary>
            /// Gets the assembly on the Specifier.
            /// </summary>
            public static readonly Specifier Assembly = "assembly";
            /// <summary>
            /// Gets the class on the Specifier.
            /// </summary>
            public static readonly Specifier Class = "class";
            /// <summary>
            /// Gets the constructor on the Specifier.
            /// </summary>
            public static readonly Specifier Constructor = "constructor";
            /// <summary>
            /// Gets the delegate on the Specifier.
            /// </summary>
            public static readonly Specifier Delegate = "delegate";
            /// <summary>
            /// Gets the enum on the Specifier.
            /// </summary>
            public static readonly Specifier Enum = "enum";
            /// <summary>
            /// Gets the event on the Specifier.
            /// </summary>
            public static readonly Specifier Event = "event";
            /// <summary>
            /// Gets the field on the Specifier.
            /// </summary>
            public static readonly Specifier Field = "field";
            /// <summary>
            /// Gets the interface on the Specifier.
            /// </summary>
            public static readonly Specifier Interface = "interface";
            /// <summary>
            /// Gets the method on the Specifier.
            /// </summary>
            public static readonly Specifier Method = "method";
            /// <summary>
            /// Gets the module on the Specifier.
            /// </summary>
            public static readonly Specifier Module = "module";
            /// <summary>
            /// Gets the none on the Specifier.
            /// </summary>
            public static readonly Specifier None = string.Empty;
            /// <summary>
            /// Gets the param on the Specifier.
            /// </summary>
            public static readonly Specifier Param = "param";
            /// <summary>
            /// Gets the property on the Specifier.
            /// </summary>
            public static readonly Specifier Property = "property";
            /// <summary>
            /// Gets the record on the Specifier.
            /// </summary>
            public static readonly Specifier Record = "record";
            /// <summary>
            /// Gets the return on the Specifier.
            /// </summary>
            public static readonly Specifier Return = "return";
            /// <summary>
            /// Gets the struct on the Specifier.
            /// </summary>
            public static readonly Specifier Struct = "struct";
            /// <summary>
            /// Gets the type on the Specifier.
            /// </summary>
            public static readonly Specifier Type = "type";
            /// <summary>
            /// Gets the typevar on the Specifier.
            /// </summary>
            public static readonly Specifier Typevar = "typevar";

            private Specifier(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Defines the string operator for the Specifier.
            /// </summary>
            public static implicit operator string(Specifier specifier)
            {
                Guard.Against.Conversion<Specifier, string>(specifier);

                return specifier.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Specifier.
            /// </summary>
            public static implicit operator Snippet(Specifier specifier)
            {
                Guard.Against.Conversion<Specifier, Snippet>(specifier);

                return Snippet.From(specifier);
            }

            /// <summary>
            /// Returns the string representation of the Specifier.
            /// </summary>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}