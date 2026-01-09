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
    /// Represents a C# member syntax event.
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Represents a C# member syntax methods.
        /// </summary>
        [AutoInitializeWith(nameof(Default))]
        [Fluentify]
        [Valuify]
        public sealed partial class Methods
        {
            /// <summary>
            /// Gets the default instance.
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
            /// <value>The add.</value>
            public Snippet Add { get; internal set; } = Snippet.Empty;

            /// <summary>
            /// Gets a value indicating whether the Methods is default.
            /// </summary>
            /// <value>A value indicating whether the Methods is default.</value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets or sets the remove on the Methods.
            /// </summary>
            /// <value>The remove.</value>
            public Snippet Remove { get; internal set; } = Snippet.Empty;

            /// <summary>
            /// Defines the string operator for the Methods.
            /// </summary>
            /// <param name="methods">The methods.</param>
            /// <returns>The string.</returns>
            public static implicit operator string(Methods methods)
            {
                Guard.Against.Conversion<Methods, string>(methods);

                return methods.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Methods.
            /// </summary>
            /// <param name="methods">The methods.</param>
            /// <returns>The snippet.</returns>
            public static implicit operator Snippet(Methods methods)
            {
                Guard.Against.Conversion<Methods, Snippet>(methods);

                return Snippet.From(methods);
            }

            /// <summary>
            /// Returns the string representation of the Methods.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return ToSnippet(Snippet.Options.Default);
            }

            /// <summary>
            /// Creates a snippet representation of the C# member syntax.
            /// </summary>
            /// <param name="options">The options.</param>
            /// <returns>The generated snippet.</returns>
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