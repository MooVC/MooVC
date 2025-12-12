namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
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

            public Snippet Add { get; set; } = Snippet.Empty;

            [Ignore]
            public bool IsDefault => this == Default;

            public Snippet Remove { get; set; } = Snippet.Empty;

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
                return ToString(Snippet.Options.Default);
            }

            public string ToString(Snippet.Options options)
            {
                _ = Guard.Against.Null(
                    options,
                    message: MethodsToStringOptionsRequired.Format(
                        nameof(Snippet.Options),
                        nameof(Snippet),
                        nameof(Methods)));

                if (IsDefault)
                {
                    return string.Empty;
                }

                Snippet add = Format("add", options, Add);
                Snippet remove = Format("remove", options, Remove);

                return remove
                    .Stack(options, add)
                    .ToString(options);
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet)
            {
                if (snippet.IsEmpty)
                {
                    return Snippet.From($"{keyword};");
                }

                if (snippet.IsSingleLine)
                {
                    return Snippet.From($"{keyword} => {snippet};");
                }

                return snippet.Block(options, opening: Snippet.From(keyword));
            }
        }
    }
}