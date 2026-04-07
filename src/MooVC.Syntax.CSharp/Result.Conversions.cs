namespace MooVC.Syntax.CSharp
{
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.Result_Resources;
    using CType = System.Type;

    /// <summary>
    /// Represents a C# syntax element result.
    /// </summary>
    public partial class Result
    {
        /// <summary>
        /// Wraps the Result in a type.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <returns>The result.</returns>
        public Result As(CType wrapper)
        {
            _ = Guard.Against.Null(wrapper, message: AsWrapperRequired.Format(typeof(Modifiers), typeof(Result)));

            Symbol wrapped = new Symbol()
                .From(wrapper)
                .Named(wrapper)
                .WithArguments(Type);

            return this.OfType(wrapped);
        }

        /// <summary>
        /// Wraps the Result in a task.
        /// </summary>
        /// <returns>The result.</returns>
        public Result AsTask()
        {
            return As(typeof(Task));
        }

        /// <summary>
        /// Wraps the Result in a value task.
        /// </summary>
        /// <returns>The result.</returns>
        public Result AsValueTask()
        {
            return As(typeof(ValueTask));
        }
    }
}