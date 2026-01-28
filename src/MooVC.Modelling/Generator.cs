namespace MooVC.Modelling;

using System;
using System.Collections.Generic;
using Graphify;
using Microsoft.Extensions.DependencyInjection;

internal sealed class Generator<TModel>(IServiceProvider provider)
    : IGenerator<TModel>
    where TModel : class
{
    public IAsyncEnumerable<File> Generate(TModel model, CancellationToken cancellationToken)
    {
        INavigator<TModel> navigator = provider.GetRequiredService<INavigator<TModel>>();

        return navigator.Navigate<File>(model, cancellationToken);
    }
}