namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.CSharp;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Property;
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

            public Setter Set { get; set; } = Setter.Default;

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

                Snippet get = Format("get", options, Get);

                if (Set.Mode.IsReadOnly)
                {
                    return get.ToString(options);
                }

                if (Set.Scope == scope)
                {
                    scope = Set.Scope;
                }

                Snippet set = Format(Set.Mode.ToString(), options, Set.Behaviour, scope: scope);

                return set
                    .Stack(options, get)
                    .ToString(options);
            }

            private static Snippet Format(string keyword, Snippet.Options options, Snippet snippet, Scope scope = default)
            {
                if (snippet.IsEmpty)
                {
                    return Snippet.From($"{keyword};");
                }

                keyword = scope is null
                    ? keyword
                    : $"{scope} {keyword}";

                return snippet.Block(options, opening: Snippet.From(keyword));
            }
        }

        [Fluentify]
        [Valuify]
        public sealed partial class Setter
        {
            public static readonly Setter Default = new Setter();

            public Snippet Behaviour { get; set; } = Snippet.Empty;

            [Ignore]
            public bool IsDefault => this == Default;

            public Mode Mode { get; set; } = Mode.Set;

            public Scope Scope { get; set; }
        }

        [Monify(Type = typeof(int))]
        public sealed partial class Mode
        {
            public static readonly Mode Init = 2;
            public static readonly Mode ReadOnly = 1;
            public static readonly Mode Set = 0;

            internal Mode(int value)
            {
                _value = value;
            }

            public bool IsInit => this == Init;

            public bool IsReadOnly => this == ReadOnly;

            public bool IsSet => this == Set;

            public override string ToString()
            {
                if (IsInit)
                {
                    return "init";
                }

                if (IsSet)
                {
                    return "set";
                }

                return string.Empty;
            }
        }
    }
}