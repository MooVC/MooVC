namespace MooVC.Data;

using System.Collections.ObjectModel;

/// <summary>
/// A contract that states that a given component supports the stated features.
/// </summary>
/// <typeparam name="TAttribute">The type of the attribute that the implementation exhibits.</typeparam>
public interface IFeatures<TAttribute>
    where TAttribute : class
{
    /// <summary>
    /// Gets the features supported by the implementation.
    /// </summary>
    /// <value>
    /// The features supported by the implementation.
    /// </value>
    Collection<TAttribute> Attributes { get; }
}