namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;
    using Monify;

    public partial class Result
    {
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Modality
        {
            public static readonly Modality Asynchronous = "async";
            public static readonly Modality Synchronous = string.Empty;

            internal Modality(string value)
            {
                _value = value;
            }

            public override string ToString()
            {
                return _value;
            }
        }
    }
}