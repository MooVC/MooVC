namespace MooVC.Modelling;

public partial class FileSystemWriter
{
    public sealed record Options(int BufferSize)
    {
        public const string SectionName = nameof(FileSystemWriter);

        public static readonly Options Default = new(4096);

        public Options()
            : this(Default.BufferSize)
        {
        }
    }
}