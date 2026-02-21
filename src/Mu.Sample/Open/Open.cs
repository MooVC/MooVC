namespace Mu.Sample.Open;

using Mu.Modelling.Behavior;
using Mu.Sample.Account;

public sealed record Open(Owner Owner)
    : Creational<Account>;