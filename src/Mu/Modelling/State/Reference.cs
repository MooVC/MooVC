namespace Mu.Modelling.State;

public readonly record struct Reference<TIdentity>
    where TIdentity : struct
{
    internal Reference(TIdentity identity, ulong revision)
    {
        Identity = identity;
        Revision = revision;
    }

    public bool IsUnspecified => Revision == ulong.MinValue;

    public TIdentity Identity { get; }

    public ulong Revision { get; }
}