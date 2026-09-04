namespace MooVC.Modelling
{
    using System.Diagnostics;

    /// <summary>
    /// Writes generated modelling files to the local file system.
    /// </summary>
    public partial class FileSystemWriter
    {
        /// <summary>
        /// Represents configuration options for <see cref="FileSystemWriter"/>.
        /// </summary>
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
        public sealed class Options
        {
            /// <summary>
            /// Gets the configuration section name for these options.
            /// </summary>
            public const string SectionName = nameof(FileSystemWriter);

            /// <summary>
            /// Gets the default options instance.
            /// </summary>
            public static readonly Options Default = new Options(4096);

            /// <summary>
            /// Initializes a new instance of the <see cref="Options"/> class.
            /// </summary>
            public Options()
                : this(Default.BufferSize)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Options"/> class.
            /// </summary>
            /// <param name="bufferSize">The size of the file buffer to use.</param>
            public Options(int bufferSize)
            {
                BufferSize = bufferSize;
            }

            /// <summary>
            /// Gets or sets the size of the file buffer to use.
            /// </summary>
            public int BufferSize { get; set; }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Options)} {{ {nameof(BufferSize)} = `{DebuggerDisplayFormatter.Format(BufferSize)}` }}";
            }
        }
    }
}