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

            internal Methods()
            {
            }

            public Snippet Get { get; internal set; } = Snippet.Empty;

            [Ignore]
            public bool IsDefault => this == Default;

            public Setter Set { get; internal set; } = Setter.Default;

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
                return ToString(Snippet.Options.Default, Scope.Public);
            }

            public string ToString(Snippet.Options options, Scope scope)
            {
                _ = Guard.Against.Null(
                    options,
                    message: MethodsToStringOptionsRequired.Format(
                        nameof(Snippet.Options),
                        nameof(Snippet),
                        nameof(Methods)));

                if (Set.Mode.IsReadOnly)
                {
                    return Get.ToString();
                }

                Snippet get = Format("get", options, Get);

                scope = Set.Scope == scope
                    ? default
                    : Set.Scope;

                Snippet set = Format(Set.Mode.ToString(), options, Set.Behaviour, scope: scope);

                if (Get.IsEmpty && Set.Behaviour.IsEmpty && get.IsSingleLine && set.IsSingleLine)
                {
                    return $"{get} {set}";
                }

                return set
                    .Stack(options, get)
                    .ToString();
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