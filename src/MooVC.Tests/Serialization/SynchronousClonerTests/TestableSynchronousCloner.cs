namespace MooVC.Serialization.SynchronousClonerTests;

using System;

public sealed class TestableSynchronousCloner
    : SynchronousCloner
{
    private readonly Func<object, object> onClone;

    public TestableSynchronousCloner(Func<object, object> onClone)
    {
        this.onClone = onClone;
    }

    protected override T PerformClone<T>(T original)
    {
        return (T)onClone(original);
    }
}