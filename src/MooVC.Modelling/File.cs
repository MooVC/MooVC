namespace MooVC.Modelling
{
    using static System.IO.Path;

    /// <summary>
    /// Represents a file to be written by a modelling writer.
    /// </summary>
    public sealed class File
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        /// <param name="content">The file content.</param>
        /// <param name="extension">The file extension.</param>
        /// <param name="name">The file name without extension.</param>
        /// <param name="path">The file path relative to the output root.</param>
        public File(string content, string extension, string name, string path)
        {
            Content = content;
            Extension = extension;
            Name = name;
            Path = path;
        }

        /// <summary>
        /// Gets the file content.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public string Extension { get; }

        /// <summary>
        /// Gets the file name including the extension.
        /// </summary>
        public string FullName
        {
            get
            {
                return string.Concat(Name, ".", Extension);
            }
        }

        /// <summary>
        /// Gets the file path including the file name.
        /// </summary>
        public string FullPath
        {
            get
            {
                return Combine(Path, FullName);
            }
        }

        /// <summary>
        /// Gets the file name without extension.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the file path relative to the output root.
        /// </summary>
        public string Path { get; }
    }
}