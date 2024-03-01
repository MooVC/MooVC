namespace MooVC.Data;

/// <summary>
/// A contract that states that a given component supports the stated feature.
/// </summary>
/// <typeparam name="TAttribute">The type of the attribute that the implementation exhibits.</typeparam>
public interface IFeature<TAttribute>
    where TAttribute : class
{
    /// <summary>
    /// Gets or Sets the feature supported by the implementation.
    /// </summary>
    /// <value>
    /// The feature supported by the implementation.
    /// </value>
    TAttribute Attribute { get; set; }
}