namespace MooVC.Modelling;

using System;
using System.Collections.Generic;
using Graphify;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Generates modelling files by navigating a model graph.
/// </summary>
/// <typeparam name="TModel">The model type.</typeparam>
/// <param name="provider">The service provider used to resolve the navigator.</param>
internal sealed class Generator<TModel>(IServiceProvider provider)
    : IGenerator<TModel>
    where TModel : class
{
    /// <summary>
    /// Generates files for the provided model.
    /// </summary>
    /// <param name="model">The model to generate from.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The generated files.</returns>
    public IAsyncEnumerable<File> Generate(TModel model, CancellationToken cancellationToken)
    {
        INavigator<TModel> navigator = provider.GetRequiredService<INavigator<TModel>>();

        return navigator.Navigate<File>(model, cancellationToken);
    }
}