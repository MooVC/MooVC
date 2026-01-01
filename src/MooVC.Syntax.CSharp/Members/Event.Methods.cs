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

    public partial class Event
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Methods
        {
            public static readonly Methods Default = new Methods();

            internal Methods()
            {
            }

            public Snippet Add { get; internal set; } = Snippet.Empty;

            [Ignore]
            public bool IsDefault => this == Default;

            public Snippet Remove { get; internal set; } = Snippet.Empty;

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