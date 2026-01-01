namespace MooVC.Syntax.Attributes.Project
{
    using Monify;

    /// <summary>
    /// Represents a msbuild project attribute target task.
    /// </summary>
    public partial class TargetTask
    {
        /// <summary>
        /// Defines options for the TargetTask msbuild project attribute.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the warn and continue option for the TargetTask msbuild project attribute.
            /// </summary>
            public static readonly Options WarnAndContinue = "WarnAndContinue";
            /// <summary>
            /// Gets the error and continue option for the TargetTask msbuild project attribute.
            /// </summary>
            public static readonly Options ErrorAndContinue = "ErrorAndContinue";
            /// <summary>
            /// Gets the error and stop option for the TargetTask msbuild project attribute.
            /// </summary>
            public static readonly Options ErrorAndStop = "ErrorAndStop ";

            private Options(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Returns the string representation of the Options.
            /// </summary>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}