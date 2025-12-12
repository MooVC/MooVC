namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Scope
    {
        public static readonly Scope File = "file";
        public static readonly Scope Internal = "internal";
        public static readonly Scope Public = "public";
        public static readonly Scope Private = "private";
        public static readonly Scope PrivateProtected = "private protected";
        public static readonly Scope Protected = "protected";
        public static readonly Scope ProtectedInternal = "protected internal";
        public static readonly Scope Unspecified = string.Empty;

        internal Scope(string value)
        {
            _value = value;
        }

        public bool IsFile => this == File;

        public bool IsInternal => this == Internal;

        public bool IsPublic => this == Public;

        public bool IsPrivate => this == Private;

        public bool IsPrivateProtected => this == PrivateProtected;

        public bool IsProtected => this == Protected;

        public bool IsProtectedInternal => this == ProtectedInternal;

        public bool IsUnspecified => this == Unspecified;

        public static implicit operator string(Scope scope)
        {
            Guard.Against.Conversion<Scope, string>(scope);

            return scope.ToString();
        }

        public static implicit operator Snippet(Scope scope)
        {
            Guard.Against.Conversion<Scope, Snippet>(scope);

            return Snippet.From(scope);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}