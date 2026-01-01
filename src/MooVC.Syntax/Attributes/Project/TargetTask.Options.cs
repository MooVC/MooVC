namespace MooVC.Syntax.Attributes.Project
{
    using Monify;

    public partial class TargetTask
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Options
        {
            public static readonly Options WarnAndContinue = "WarnAndContinue";
            public static readonly Options ErrorAndContinue = "ErrorAndContinue";
            public static readonly Options ErrorAndStop = "ErrorAndStop ";

            private Options(string value)
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