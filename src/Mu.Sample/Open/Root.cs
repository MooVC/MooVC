namespace Mu.Sample.Open;

using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Mu.Modelling.Integrity;
using Mu.Modelling.State;
using Mu.Sample.Account;
using Mu.Services;

public sealed class Root(IEnumerable<IInvariant<Account, Open>> invariants, IEnumerable<ITransform<Account, Opened>> transforms)
    : IRoot<Account, Open>
{
    public async Task<Result<Account>> Apply(Account account, Open open, CancellationToken cancellationToken)
    {
        ImmutableArray<ValidationResult> failures = await invariants
            .EnforceAll(account, open, cancellationToken)
            .ConfigureAwait(false);

        if (failures.Length == 0)
        {
            return account.Propose(open, transforms);
        }

        return failures;
    }
}