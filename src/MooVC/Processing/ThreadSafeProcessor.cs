namespace MooVC.Processing
{
    using System.Threading;

    public abstract class ThreadSafeProcessor
        : Processor
    {
        private const int StartRequestedFlag = 1;
        private const int StopRequestedFlag = 0;

        private volatile int flag = StopRequestedFlag;

        protected sealed override bool CanStart()
        {
            return Interlocked.CompareExchange(ref flag, StartRequestedFlag, StopRequestedFlag) == StopRequestedFlag;
        }

        protected sealed override bool CanStop()
        {
            return Interlocked.CompareExchange(ref flag, StopRequestedFlag, StartRequestedFlag) == StartRequestedFlag;
        }
    }
}