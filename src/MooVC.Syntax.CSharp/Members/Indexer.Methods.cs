namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Indexer_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    public partial class Indexer
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Methods
        {
            public static readonly Methods Default = new Methods();

            internal Methods()
            {
            }

            public Snippet Get { get; internal set; } = Snippet.Empty;

            [Ignore]
            public bool IsDefault => this == Default;

            public Snippet Set { get; internal set; } = Snippet.Empty;

            public static implicit operator string(Methods methods)
            {
                Guard.Against.Conversion<Methods, string>(methods);

                return methods.ToString();
            }

            public static implicit operator Snippet(Methods methods)
            {
                Guard.Against.Conversion<Methods, Snippet>(methods);

                return Snippet.From(methods);
            }

            public override string ToString()
            {
                return ToSnippet(Snippet.Options.Default);
            }

            public Snippet ToSnippet(Snippet.Options options)
            {
                _ = Guard.Against.Null(options, message: MethodsToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Methods)));

                Snippet add = Format("get", options, Get);

                if (!Set.IsEmpty)
                {
                    Snippet remove = Format("set", options, Set);

                    add = remove.Stack(options, add);
                }

                return add;
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet)
            {
                if (snippet.IsEmpty)
                {
                    return $"{keyword};";
                }

                return snippet.Block(options, opening: Snippet.From(options, keyword));
            }
        }
    }
}