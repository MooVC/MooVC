namespace MooVC.Logging
{
    public interface IEmitFailures
    {
        event PassiveExceptionEventHandler FailureEmitted;
    }
}