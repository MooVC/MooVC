namespace MooVC.Logging
{
    using System;

    public interface IEmitFailures
    {
        event EventHandler<ExceptionEventArgs> FailureEmitted;
    }
}