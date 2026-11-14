namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Indexer_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents an indexer declaration model.
    /// </summary>
    public partial class Indexer
    {
        /// <summary>
        /// Represents accessor methods used by indexers, properties, and events.
        /// </summary>
        [AutoInitializeWith(nameof(Default))]
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
            /// Gets the accessibility of the getter.
            /// </summary>
            /// <value>The scope or an unspecified scope to inherit the indexer accessibility.</value>
            public Scopes GetterScope { get; internal set; } = Scopes.Unspecified;

            /// <summary>
            /// Gets a value indicating whether a getter is emitted.
            /// </summary>
            /// <value><see langword="true"/> when the indexer declares a getter.</value>
            public bool HasGetter { get; internal set; } = true;

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
            public Snippet Set { get; internal set; } = Snippet.Empty;

            /// <summary>
            /// Gets the accessibility of the setter.
            /// </summary>
            /// <value>The scope or an unspecified scope to inherit the indexer accessibility.</value>
            public Scopes SetterScope { get; internal set; } = Scopes.Unspecified;

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

                return Snippet.From(methods);
            }

            /// <summary>
            /// Returns the string representation of the Methods.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return ToSnippet(Options.Default);
            }

            /// <summary>
            /// Creates a snippet representation of the C# member syntax.
            /// </summary>
            /// <param name="options">The options.</param>
            /// <returns>The generated snippet.</returns>
            public Snippet ToSnippet(Snippet.Options options)
            {
                return ToSnippet(options, Scopes.Unspecified);
            }

            /// <summary>
            /// Creates a snippet representation of the C# accessors.
            /// </summary>
            /// <param name="options">The snippet options.</param>
            /// <param name="scope">The indexer accessibility.</param>
            /// <returns>The rendered accessors.</returns>
            public Snippet ToSnippet(Snippet.Options options, Scopes scope)
            {
                _ = Guard.Against.Null(options, message: MethodsToStringOptionsRequired.Format(nameof(Methods)));

                Scopes getterScope = GetterScope == scope ? Scopes.Unspecified : GetterScope;
                Snippet get = HasGetter ? Format("get", options, Get, getterScope) : Snippet.Empty;

                if (Set.IsEmpty)
                {
                    return get;
                }

                Scopes setterScope = SetterScope == scope ? Scopes.Unspecified : SetterScope;
                Snippet set = Format("set", options, Set, setterScope);

                return HasGetter ? set.Prepend(options, get) : set;
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet, Scopes scope)
            {
                keyword = scope == Scopes.Unspecified ? keyword : $"{scope} {keyword}";

                if (snippet.IsEmpty)
                {
                    return Snippet.From(options, $"{keyword};");
                }

                return snippet.Block(options, opening: Snippet.From(options, keyword));
            }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Methods)} {{ " +
                    $"{nameof(Get)} = `{DebuggerDisplayFormatter.Format(Get)}`, " +
                    $"{nameof(GetterScope)} = `{DebuggerDisplayFormatter.Format(GetterScope)}`, " +
                    $"{nameof(HasGetter)} = `{DebuggerDisplayFormatter.Format(HasGetter)}`, " +
                    $"{nameof(IsDefault)} = `{DebuggerDisplayFormatter.Format(IsDefault)}`, " +
                    $"{nameof(Set)} = `{DebuggerDisplayFormatter.Format(Set)}`, " +
                    $"{nameof(SetterScope)} = `{DebuggerDisplayFormatter.Format(SetterScope)}` }}";
            }
        }
    }
}