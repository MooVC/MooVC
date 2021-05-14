namespace MooVC.Processing
{
    using System.Threading.Tasks;

    public delegate Task ProcessorStateChangedAsyncEventHandler(IProcessor sender, ProcessorStateChangedAsyncEventArgs e);
}