namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Property_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    public partial class Property
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Methods
        {
            public static readonly Methods Default = new Methods();

            public Snippet Get { get; set; } = Snippet.Empty;

            [Ignore]
            public bool IsDefault => this == Default;

            public Snippet Set { get; set; } = Snippet.Empty;

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

                Snippet get = Format("get", options, Get);

                if (Set.IsEmpty)
                {
                    return get.ToString(options);
                }

                Snippet set = Format("set", options, Set);

                return get
                    .Append(options, options.NewLine)
                    .Append(set)
                    .ToString(options);
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet)
            {
                if (snippet.IsEmpty)
                {
                    return Snippet.Empty;
                }

                return snippet.Block(options, opening: Snippet.From(keyword));
            }
        }
    }
}
