namespace MooVC;

using System.Threading.Tasks;

public delegate Task AsyncEventHandler(object? sender, AsyncEventArgs e);

public delegate Task AsyncEventHandler<TArgs>(object? sender, TArgs e)
    where TArgs : AsyncEventArgs;

public delegate Task AsyncEventHandler<TSender, TArgs>(TSender? sender, TArgs e)
    where TSender : class
    where TArgs : AsyncEventArgs;