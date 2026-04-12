namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Property_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a property declaration model.
    /// </summary>
    public partial class Property
    {
        /// <summary>
        /// Represents accessor methods used by indexers, properties, and events.
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
            /// Gets the get on the Methods.
            /// </summary>
            /// <value>The get.</value>
            public Snippet Get { get; internal set; } = Snippet.Empty;

            /// <summary>
            /// Gets a value indicating whether the Methods is default.
            /// </summary>
            /// <value>A value indicating whether the Methods is default.</value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets the set on the Methods.
            /// </summary>
            /// <value>The set.</value>
            public Setter Set { get; internal set; } = Setter.Default;

            /// <summary>
            /// Defines an implicit conversion from <see cref="Methods" /> to <see cref="string" />.
            /// </summary>
            /// <param name="methods">The <see cref="Methods" /> value to convert.</param>
            /// <returns>The converted <see cref="string" /> value.</returns>
            public static implicit operator string(Methods methods)
            {
                Guard.Against.Conversion<Methods, string>(methods);

                return methods.ToString();
            }

            /// <summary>
            /// Defines an implicit conversion from <see cref="Methods" /> to <see cref="Snippet" />.
            /// </summary>
            /// <param name="methods">The <see cref="Methods" /> value to convert.</param>
            /// <returns>The converted <see cref="Snippet" /> value.</returns>
            public static implicit operator Snippet(Methods methods)
            {
                Guard.Against.Conversion<Methods, Snippet>(methods);

                return Snippet.From(methods.ToString());
            }

            /// <summary>
            /// Returns the string representation of the Methods.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return ToSnippet(Options.Default, Scopes.Public);
            }

            /// <summary>
            /// Creates a snippet representation of the C# member syntax.
            /// </summary>
            /// <param name="options">The options.</param>
            /// <param name="scope">The scope.</param>
            /// <returns>The generated snippet.</returns>
            public Snippet ToSnippet(Snippet.Options options, Scopes scope)
            {
                _ = Guard.Against.Null(options, message: MethodsToStringOptionsRequired.Format(nameof(Options), nameof(Snippet), nameof(Methods)));

                if (options.Block.Inline.IsLambda && Set.Mode.IsReadOnly && !Get.IsEmpty)
                {
                    return Get;
                }

                Snippet get = Format("get", options, Get);

                if (Set.Mode.IsReadOnly)
                {
                    return get;
                }

                scope = Set.Scope == scope
                    ? default
                    : Set.Scope;

                Snippet set = Format(Set.Mode.ToString(), options, Set.Behaviour, scope: scope);

                if (Get.IsEmpty && Set.Behaviour.IsEmpty)
                {
                    return Snippet.From(options, $"{get} {set}");
                }

                return set.Prepend(options, get);
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet, Scopes scope = default)
            {
                if (snippet.IsEmpty)
                {
                    return Snippet.From(options, $"{keyword};");
                }

                keyword = scope is null || scope == Scopes.Unspecified
                    ? keyword
                    : $"{scope} {keyword}";

                return snippet.Block(options, opening: Snippet.From(options, keyword));
            }
        }
    }
}