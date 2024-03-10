namespace MooVC.Data;

using Ardalis.GuardClauses;
using static MooVC.Data.IFeatureExtensions_Resources;

/// <summary>
/// Provides extensions that support the assignment of features to a given instance.
/// </summary>
public static partial class IFeatureExtensions
{
    /// <summary>
    /// Facilitates the assignment of an <typeparamref name="TAttribute"/> through the specified <paramref name="attribute"/>.
    /// </summary>
    /// <typeparam name="TAttribute">The type of attribute supported by the <paramref name="subject"/>.</typeparam>
    /// <typeparam name="TSubject">
    /// The type of the component that supports the stated <paramref name="attribute"/>, upon which the assignment will be made.
    /// </typeparam>
    /// <param name="subject">The component that supports the stated <paramref name="attribute"/>, upon which the assignment will be made.</param>
    /// <param name="attribute">A function that facilitates customization of the attribute to be assigned to the <paramref name="subject"/>.</param>
    /// <returns>The <paramref name="subject"/> with the <paramref name="attribute"/> assigned.</returns>
    public static TSubject With<TAttribute, TSubject>(this TSubject subject, Mutator<TAttribute> attribute)
        where TAttribute : class, new()
        where TSubject : IFeature<TAttribute>
    {
        _ = Guard.Against.Null(subject, message: WithSubjectRequired.Format(typeof(TSubject), attribute));
        _ = Guard.Against.Null(attribute, message: WithAttributeRequired.Format(typeof(TAttribute), subject));

        subject.Attribute = attribute(new());

        return subject;
    }

    /// <summary>
    /// Facilitates the assignment of an <typeparamref name="TAttribute"/> through the specified <paramref name="attribute"/>.
    /// </summary>
    /// <typeparam name="TAttribute">The type of attribute supported by the <paramref name="subject"/>.</typeparam>
    /// <typeparam name="TSubject">
    /// The type of the component that supports the stated <paramref name="attribute"/>, upon which the assignment will be made.
    /// </typeparam>
    /// <param name="subject">The component that supports the stated <paramref name="attribute"/>, upon which the assignment will be made.</param>
    /// <param name="attribute">The attribute to be assigned to the <paramref name="subject"/>.</param>
    /// <returns>The <paramref name="subject"/> with the <paramref name="attribute"/> assigned.</returns>
    public static TSubject With<TAttribute, TSubject>(this TSubject subject, TAttribute attribute)
        where TAttribute : class
        where TSubject : IFeature<TAttribute>
    {
        _ = Guard.Against.Null(subject, message: WithSubjectRequired.Format(typeof(TSubject), attribute));
        _ = Guard.Against.Null(attribute, message: WithAttributeRequired.Format(typeof(TAttribute), subject));

        subject.Attribute = attribute;

        return subject;
    }
}