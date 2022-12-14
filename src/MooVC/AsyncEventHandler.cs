namespace MooVC;

using System.Threading.Tasks;

/// <summary>
/// Represents the method that will handle an asynchronous event that has event data within an abstract envelope.
/// </summary>
/// <param name="sender">The source of the event.</param>
/// <param name="e">An object that contains data relating to the event.</param>
/// <returns>A task representing the asynchronous operation.</returns>
public delegate Task AsyncEventHandler(object? sender, AsyncEventArgs e);

/// <summary>
/// Represents the method that will handle an asynchronous event that has type specific event data.
/// </summary>
/// <typeparam name="TArgs">The type of the event data.</typeparam>
/// <param name="sender">The source of the event.</param>
/// <param name="e">The type specific event data.</param>
/// <returns>A task representing the asynchronous operation.</returns>
public delegate Task AsyncEventHandler<TArgs>(object? sender, TArgs e)
    where TArgs : AsyncEventArgs;

/// <summary>
/// Represents the method that will handle an asynchronous event that has a type specific source and type specific event data.
/// </summary>
/// <typeparam name="TSender">The type of the sender.</typeparam>
/// <typeparam name="TArgs">The type of the event data.</typeparam>
/// <param name="sender">The source of the event.</param>
/// <param name="e">The type specific event data.</param>
/// <returns>A task representing the asynchronous operation.</returns>
public delegate Task AsyncEventHandler<TSender, TArgs>(TSender? sender, TArgs e)
    where TSender : class
    where TArgs : AsyncEventArgs;