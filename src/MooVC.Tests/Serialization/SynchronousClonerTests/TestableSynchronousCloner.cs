namespace MooVC.Serialization.SynchronousClonerTests;

public sealed class TestableSynchronousCloner
    : SynchronousCloner
{
    private readonly Func<object, object> _onClone;

    public TestableSynchronousCloner(Func<object, object> onClone)
    {
        _onClone = onClone;
    }

    protected override T PerformClone<T>(T original)
    {
        return (T)_onClone(original);
    }
}