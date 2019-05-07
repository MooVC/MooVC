namespace MooVC.Logging
{
    using System;

    public interface IEmitWarnings
    {
        event EventHandler<ExceptionEventArgs> WarningEmitted;
    }
}