namespace MooVC.Modelling;

using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Defines a generator for modelling files from a model instance.
/// </summary>
/// <typeparam name="TModel">The model type.</typeparam>
public interface IGenerator<TModel>
    where TModel : class
{
    /// <summary>
    /// Generates files for the provided model.
    /// </summary>
    /// <param name="model">The model to generate from.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The generated files.</returns>
    IAsyncEnumerable<File> Generate(TModel model, CancellationToken cancellationToken);
}