namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.Elements.Result_Resources;

    /// <summary>
    /// Represents a c# syntax element result.
    /// </summary>
    public partial class Result
    {
        /// <summary>
        /// Wraps the Result in a .
        /// </summary>
        public Result As(Type wrapper)
        {
            _ = Guard.Against.Null(wrapper, message: AsWrapperRequired.Format(typeof(Type), typeof(Result)));

            Symbol wrapped = new Symbol()
                .From(wrapper)
                .Named(wrapper)
                .WithArguments(Type);

            return this.OfType(wrapped);
        }

        /// <summary>
        /// Wraps the Result in a task.
        /// </summary>
        public Result AsTask()
        {
            return As(typeof(Task));
        }

        /// <summary>
        /// Wraps the Result in a value task.
        /// </summary>
        public Result AsValueTask()
        {
            return As(typeof(ValueTask));
        }
    }
}