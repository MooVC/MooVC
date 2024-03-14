namespace MooVC.Threading.Coordination;

/// <summary>
/// Represents an object that can direct the context in which it is coordinated.
/// </summary>
public interface ICoordinatable
{
    /// <summary>
    /// Gets the key that serves as the context in which to coordinate operations on objects of the same type.
    /// </summary>
    /// <returns>The key used to coordinate operations on objects of the same type.</returns>
    string GetKey();
}