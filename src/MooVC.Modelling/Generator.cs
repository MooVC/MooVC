namespace MooVC.Modelling
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Graphify;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Generates modelling files by navigating a model graph.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    internal sealed class Generator<TModel>
        : IGenerator<TModel>
        where TModel : class
    {
        private readonly IServiceProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Generator{TModel}"/> class.
        /// </summary>
        public Generator(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Generates files for the provided model.
        /// </summary>
        public IAsyncEnumerable<File> Generate(TModel model, CancellationToken cancellationToken)
        {
            INavigator<TModel> navigator = _provider.GetRequiredService<INavigator<TModel>>();

            return navigator.Navigate<File>(model, cancellationToken);
        }
    }
}
