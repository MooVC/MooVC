namespace MooVC.Modelling;

public partial class FileSystemWriter
{
    public sealed record Options(int BufferSize)
    {
        public static readonly Options Default = new(4096);
    }
}