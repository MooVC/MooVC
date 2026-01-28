namespace MooVC.Modelling;

public partial class FileSystemWriter
{
    /// <summary>
    /// Represents configuration options for <see cref="FileSystemWriter"/>.
    /// </summary>
    public sealed record Options(int BufferSize)
    {
        /// <summary>
        /// Gets the configuration section name for these options.
        /// </summary>
        public const string SectionName = nameof(FileSystemWriter);

        /// <summary>
        /// Gets the default options instance.
        /// </summary>
        public static readonly Options Default = new(4096);

        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> record.
        /// </summary>
        public Options()
            : this(Default.BufferSize)
        {
        }
    }
}