namespace Graphify
{
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Defines navigation over a model to produce output values.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    public interface INavigator<TModel>
        where TModel : class
    {
        /// <summary>
        /// Navigates the model and yields output values.
        /// </summary>
        /// <typeparam name="TOutput">The output value type.</typeparam>
        /// <param name="model">The model instance to navigate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An asynchronous sequence of output values.</returns>
        IAsyncEnumerable<TOutput> Navigate<TOutput>(TModel model, CancellationToken cancellationToken);
    }
}