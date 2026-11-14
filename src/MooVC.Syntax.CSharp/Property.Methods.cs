namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics;
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
            /// <value>The scope or an unspecified scope to inherit the property accessibility.</value>
            public Scopes GetterScope { get; internal set; } = Scopes.Unspecified;

            /// <summary>
            /// Gets a value indicating whether a getter is emitted.
            /// </summary>
            /// <value><see langword="true"/> when the property declares a getter.</value>
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
                _ = Guard.Against.Null(options, message: MethodsToStringOptionsRequired.Format(typeof(Methods)));

                Scopes getterScope = GetterScope == scope ? Scopes.Unspecified : GetterScope;

                if (HasGetter && options.Block.Inline.IsLambda && Set.Mode.IsReadOnly && !Get.IsEmpty && getterScope == Scopes.Unspecified)
                {
                    return Get;
                }

                Snippet get = HasGetter ? Format("get", options, Get, getterScope) : Snippet.Empty;

                if (Set.Mode.IsReadOnly)
                {
                    return get;
                }

                Scopes setterScope = Set.Scope == scope ? Scopes.Unspecified : Set.Scope;
                Snippet set = Format(Set.Mode.ToString(), options, Set.Behaviour, setterScope);

                if (!HasGetter)
                {
                    return set;
                }

                if (Get.IsEmpty && Set.Behaviour.IsEmpty)
                {
                    return Snippet.From(options, $"{get} {set}");
                }

                return set.Prepend(options, get);
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet, Scopes scope = default)
            {
                keyword = scope is null || scope == Scopes.Unspecified
                    ? keyword
                    : $"{scope} {keyword}";

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
                    $"{nameof(Set)} = `{DebuggerDisplayFormatter.Format(Set)}` }}";
            }
        }
    }
}