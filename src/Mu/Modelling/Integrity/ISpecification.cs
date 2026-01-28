namespace Mu.Modelling.Integrity;

using System.ComponentModel.DataAnnotations;
using Mu.Modelling.Behavior;

public interface ISpecification<in TIntent>
    where TIntent : NonMutational
{
    IAsyncEnumerable<ValidationResult> Enforce(TIntent intent, CancellationToken cancellationToken);
}