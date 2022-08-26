namespace MooVC.Threading;

using System;

public interface ICoordinationContext<T>
    : IDisposable
    where T : notnull
{
    T Context { get; }

    TimeSpan Duration { get; }

    DateTimeOffset TimeStamp { get; }
}