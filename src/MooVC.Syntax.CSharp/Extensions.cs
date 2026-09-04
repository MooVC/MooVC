namespace MooVC.Syntax.CSharp
{
    /// <summary>
    /// Provides constants used by C# syntax modelling extensions.
    /// </summary>
    /// <remarks>
    /// These values are used when generating file names for C# source and project artifacts.
    /// </remarks>
    public static class Extensions
    {
        /// <summary>
        /// Gets the default C# source code file extension.
        /// </summary>
        /// <value>The <c>cs</c> extension without a leading dot.</value>
        public static readonly string Code = "cs";

        /// <summary>
        /// Gets the default C# project file extension.
        /// </summary>
        /// <value>The <c>csproj</c> extension without a leading dot.</value>
        public static readonly string Project = "csproj";
    }
}