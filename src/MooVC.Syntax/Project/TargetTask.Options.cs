namespace MooVC.Syntax.Project
{
    using System.Diagnostics;
    using Monify;

    /// <summary>
    /// Represents a MSBuild project attribute target task.
    /// </summary>
    public partial class TargetTask
    {
        /// <summary>
        /// Defines options for the TargetTask MSBuild project attribute.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Options
        {
            /// <summary>
            /// Represents the warn and continue for the Options.
            /// </summary>
            public static readonly Options WarnAndContinue = "WarnAndContinue";

            /// <summary>
            /// Represents the error and continue for the Options.
            /// </summary>

            public static readonly Options ErrorAndContinue = "ErrorAndContinue";

            /// <summary>
            /// Represents the error and stop for the Options.
            /// </summary>
            public static readonly Options ErrorAndStop = "ErrorAndStop";

            private Options(string value)
            {
                _value = value;
            }
        }
    }
}