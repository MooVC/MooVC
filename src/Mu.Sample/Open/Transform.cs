namespace Mu.Sample.Open;

using Mu.Sample.Account;
using Mu.Services;

internal sealed class Transform
    : ITransform<Account, Opened>
{
    public Account Apply(Account account, Opened opened)
    {
        return account with
        {
            Owner = opened.Owner,
        };
    }
}