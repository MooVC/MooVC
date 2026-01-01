namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Event_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a c# member syntax event.
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Represents a c# member syntax methods.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class Methods
        {
            /// <summary>
            /// Gets the default on the Methods.
            /// </summary>
            public static readonly Methods Default = new Methods();

            /// <summary>
            /// Initializes a new instance of the Methods class.
            /// </summary>
            internal Methods()
            {
            }

            /// <summary>
            /// Gets or sets the add on the Methods.
            /// </summary>
            public Snippet Add { get; internal set; } = Snippet.Empty;

            /// <summary>
            /// Gets a value indicating whether the Methods is default.
            /// </summary>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets or sets the remove on the Methods.
            /// </summary>
            public Snippet Remove { get; internal set; } = Snippet.Empty;

            /// <summary>
            /// Defines the string operator for the Methods.
            /// </summary>
            public static implicit operator string(Methods methods)
            {
                Guard.Against.Conversion<Methods, string>(methods);

                return methods.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Methods.
            /// </summary>
            public static implicit operator Snippet(Methods methods)
            {
                Guard.Against.Conversion<Methods, Snippet>(methods);

                return Snippet.From(methods);
            }

            /// <summary>
            /// Returns the string representation of the Methods.
            /// </summary>
            public override string ToString()
            {
                return ToSnippet(Snippet.Options.Default);
            }

            /// <summary>
            /// Creates a code snippet representation of the c# member syntax.
            /// </summary>
            public Snippet ToSnippet(Snippet.Options options)
            {
                _ = Guard.Against.Null(
                    options,
                    message: MethodsToSnippetOptionsRequired.Format(
                        nameof(Snippet.Options),
                        nameof(Snippet),
                        nameof(Methods)));

                if (IsDefault)
                {
                    return string.Empty;
                }

                Snippet add = Format("add", options, Add);
                Snippet remove = Format("remove", options, Remove);

                if (Add.IsEmpty && Remove.IsEmpty)
                {
                    return Snippet.From($"{add} {remove}");
                }

                return remove.Stack(options, add);
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet)
            {
                if (snippet.IsEmpty)
                {
                    return Snippet.From($"{keyword};");
                }

                return snippet.Block(options, opening: Snippet.From(keyword));
            }
        }
    }
}