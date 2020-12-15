namespace MooVC.Logging
{
    using System;

    [Obsolete("Replaced by Diagnostics", false)]
    public interface IEmitFailures
    {
        event PassiveExceptionEventHandler FailureEmitted;
    }
}