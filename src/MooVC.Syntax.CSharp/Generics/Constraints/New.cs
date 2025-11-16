namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using Fluentify;
    using Monify;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class New
    {
        public static readonly New Required = "new()";
        public static readonly New NotRequired = string.Empty;

        internal New(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}