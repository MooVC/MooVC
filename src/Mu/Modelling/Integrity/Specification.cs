namespace Mu.Modelling.Integrity;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Mu.Modelling.Behavior;

public abstract class Specification<TIntent>
    : ISpecification<TIntent>
    where TIntent : NonMutational
{
    public IAsyncEnumerable<ValidationResult> Enforce(TIntent intent, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(intent);

        return PerformEnforce(intent, cancellationToken);
    }

    protected abstract IAsyncEnumerable<ValidationResult> PerformEnforce(TIntent intent, CancellationToken cancellationToken);
}