namespace Mu.Modelling.State;

using System.Text.Json.Serialization;

public readonly record struct Revision
{
    public Revision()
        : this(DateTimeOffset.MinValue, 0)
    {
    }

    [JsonConstructor]
    internal Revision(DateTimeOffset initiatedAt, ulong number)
    {
        InitiatedAt = initiatedAt;
        Number = number;
    }

    public DateTimeOffset InitiatedAt { get; }

    public ulong Number { get; }

    public static Revision operator ++(Revision revision)
    {
        unchecked
        {
            return new Revision(DateTimeOffset.UtcNow, revision.Number + 1);
        }
    }
}