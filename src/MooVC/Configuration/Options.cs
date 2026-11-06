namespace MooVC.Configuration
{
    /// <summary>
    /// Represents a base class for configuration options that can be used to configure various aspects of an application or library.
    /// </summary>
    /// <typeparam name="T">The type of the configuration option.</typeparam>
    public abstract class Options<T>
        where T : struct
    {
        /// <summary>
        /// Gets or sets the type of the configuration option.
        /// </summary>
        public T Type { get; set; }
    }
}