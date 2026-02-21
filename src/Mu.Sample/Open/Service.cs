namespace Mu.Sample.Open;

using System.Threading;
using Mu.Persistence;
using Mu.Sample.Account;
using Mu.Services;

public sealed class Service(IRoot<Account, Open> root, IWriteStore<Account, Guid> store)
    : IService<Open, Guid>
{
    public async Task<Result<Guid>> Execute(Open open, CancellationToken cancellationToken)
    {
        var account = new Account();
        var identity = Guid.CreateVersion7();

        return await root
            .Apply(account, open, cancellationToken)
            .Then(opened => store.Save(account, identity, cancellationToken))
            .Select(_ => identity)
            .ConfigureAwait(false);
    }
}