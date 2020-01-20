namespace MooVC.Logging
{
    public interface IEmitWarnings
    {
        event PassiveExceptionEventHandler WarningEmitted;
    }
}