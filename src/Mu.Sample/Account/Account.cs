namespace Mu.Sample.Account;

using Mu.Modelling.State;

public sealed record Account
    : Aggregate
{
    public Owner Owner { get; init; } = Owner.Unspecified;
}