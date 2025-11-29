namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.Members.Result_Resources;

    public partial class Result
    {
        public Result As(Type wrapper)
        {
            _ = Guard.Against.Null(wrapper, message: AsWrapperRequired.Format(typeof(Type), typeof(Result)));

            Symbol wrapped = new Symbol()
                .WithName(wrapper)
                .WithQualifier(wrapper)
                .WithArguments(Type);

            return this.WithType(wrapped);
        }

        public Result AsTask()
        {
            return As(typeof(Task));
        }

        public Result AsValueTask()
        {
            return As(typeof(ValueTask));
        }
    }
}