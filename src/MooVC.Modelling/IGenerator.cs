namespace MooVC.Modelling;

using System.Collections.Generic;
using System.Threading;

public interface IGenerator<TModel> where TModel : class
{
    IAsyncEnumerable<File> Generate(TModel model, CancellationToken cancellationToken);
}