namespace MooVC.Compression
{
    using Microsoft.Extensions.Configuration;
    using MooVC.Composition;
    using MooVC.Compression.Configuration;

    /// <summary>
    /// Defines a factory for creating instances of <see cref="GZipCompressor"/>.
    /// </summary>
    public partial class GZipCompressor
    {
        /// <summary>
        /// Defines a factory for creating instances of <see cref="GZipCompressor"/>.
        /// </summary>
        public sealed class Factory
            : IInstanceStrategy<ICompressor, Type>
        {
            /// <summary>
            /// Attempts to create an instance of <see cref="GZipCompressor"/> based on the specified options and type.
            /// </summary>
            /// <param name="configuration">The configuration to use when creating the instance.</param>
            /// <param name="type">The type of the instance to create.</param>
            /// <param name="instance">The created instance, or the default value if creation fails.</param>
            /// <returns><c>true</c> if the instance was created successfully; otherwise, <c>false</c>.</returns>
            public bool TryCreate(IConfigurationSection configuration, Type type, out ICompressor instance)
            {
                if (type == GZip)
                {
                    Options options = configuration.Get<Options>();
                    instance = new GZipCompressor(options);

                    return true;
                }

                instance = default;

                return false;
            }
        }
    }
}