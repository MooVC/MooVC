namespace MooVC.Syntax.CSharp.Members
{
    using Monify;

    public partial class Argument
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Formatter
        {
            public static readonly Formatter Call = new Formatter("{0}: {1}");
            public static readonly Formatter Declaration = new Formatter("{0} = {1}");

            internal Formatter(string value)
            {
                _value = value;
            }
        }
    }
}