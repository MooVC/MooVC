namespace MooVC.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Faciliates implementation of a synchronous implementation of the <see cref="ICloner" /> contract for cloning objects.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    public abstract class SynchronousCloner
        : ICloner
    {
        /// <summary>
        /// Asynchronously clones the specified object.
        /// </summary>
        /// <typeparam name="T">The type of the object to clone.</typeparam>
        /// <param name="original">The original object to clone.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
        /// <returns>
        /// A <see cref="Task{TResult}" /> that represents the asynchronous clone operation.
        /// The task result contains the cloned object.
        /// </returns>
        public Task<T> Clone<T>(T original, CancellationToken cancellationToken)
        {
            return Task.FromResult(PerformClone(original));
        }

        /// <summary>
        /// Facilitates synchronously cloning of the specified object.
        /// </summary>
        /// <typeparam name="T">The type of the object to clone.</typeparam>
        /// <param name="original">The original object to clone.</param>
        /// <returns>The cloned object.</returns>
        protected abstract T PerformClone<T>(T original);

        private string GetDebuggerDisplay()
        {
            return $"{nameof(SynchronousCloner)} {{ {GetHashCode()} }}";
        }
    }
}