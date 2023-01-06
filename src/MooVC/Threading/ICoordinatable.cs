namespace MooVC.Threading;

/// <summary>
/// Represents an object that can direct the context in which it is coordinated.
/// </summary>
/// <typeparam name="T">The type of the key used to coordinate objects of this type.</typeparam>
public interface ICoordinatable<T>
    where T : notnull
{
    /// <summary>
    /// Gets the key that serves as the context in which to coordinate operations on objects of the same type.
    /// </summary>
    /// <returns>The key used to coordinate operations on objects of the same type.</returns>
    T GetKey();
}