namespace MooVC
{
    using System;
    using System.Threading.Tasks;

    public delegate Task AsyncEventHandler(object? sender, EventArgs e);

    public delegate Task AsyncEventHandler<TArgs>(object? sender, TArgs e)
        where TArgs : EventArgs;

    public delegate Task AsyncEventHandler<TSender, TArgs>(TSender? sender, TArgs e)
        where TSender : class
        where TArgs : EventArgs;
}