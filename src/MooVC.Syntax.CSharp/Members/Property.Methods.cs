namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Property_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax property.
    /// </summary>
    public partial class Property
    {
        /// <summary>
        /// Represents a C# member syntax methods.
        /// </summary>
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
            /// Gets or sets the get on the Methods.
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
            /// Gets or sets the set on the Methods.
            /// </summary>
            /// <value>The set.</value>
            public Setter Set { get; internal set; } = Setter.Default;

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
                return ToSnippet(Snippet.Options.Default, Scope.Public);
            }

            /// <summary>
            /// Creates a snippet representation of the C# member syntax.
            /// </summary>
            /// <param name="options">The options.</param>
            /// <param name="scope">The scope.</param>
            /// <returns>The generated snippet.</returns>
            public Snippet ToSnippet(Snippet.Options options, Scope scope)
            {
                _ = Guard.Against.Null(options, message: MethodsToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Methods)));

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

                return set.Stack(options, get);
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet, Scope scope = default)
            {
                if (snippet.IsEmpty)
                {
                    return Snippet.From($"{keyword};");
                }

                keyword = scope is null || scope == Scope.Unspecified
                    ? keyword
                    : $"{scope} {keyword}";

                return snippet.Block(options, opening: Snippet.From(keyword));
            }
        }
    }
}