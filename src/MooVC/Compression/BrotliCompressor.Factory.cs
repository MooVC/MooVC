#if NET6_0_OR_GREATER
namespace MooVC.Compression
{
    using Microsoft.Extensions.Configuration;
    using MooVC.Composition;
    using MooVC.Compression.Configuration;

    /// <summary>
    /// Represents a factory for creating instances of <see cref="BrotliCompressor"/>.
    /// </summary>
    public partial class BrotliCompressor
    {
        /// <summary>
        /// Represents a factory for creating instances of <see cref="BrotliCompressor"/>.
        /// </summary>
        public sealed class Factory
            : IInstanceStrategy<ICompressor, Type>
        {
            /// <summary>
            /// Attempts to create an instance of <see cref="BrotliCompressor"/> based on the specified options and type.
            /// </summary>
            /// <param name="configuration">The configuration to use when creating the instance.</param>
            /// <param name="type">The type of the instance to create.</param>
            /// <param name="instance">The created instance, or the default value if creation fails.</param>
            /// <returns><c>true</c> if the instance was created successfully; otherwise, <c>false</c>.</returns>
            public bool TryCreate(IConfigurationSection configuration, Type type, out ICompressor instance)
            {
                if (type == Brotli)
                {
                    Options options = configuration.Get<Options>();
                    instance = new BrotliCompressor(options);

                    return true;
                }

                instance = default;

                return false;
            }
        }
    }
}
#endif