namespace MooVC.Modelling;

internal partial class FileSystemWriter
{
    public sealed record Options(int BufferSize)
    {
        public static readonly Options Default = new(4096);
    }
}