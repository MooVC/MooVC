namespace MooVC.Logging
{
    using System;

    [Obsolete("Replaced by Diagnostics", false)]
    public interface IEmitWarnings
    {
        event PassiveExceptionEventHandler WarningEmitted;
    }
}