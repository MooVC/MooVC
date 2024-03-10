namespace MooVC.Data;

using Ardalis.GuardClauses;
using MooVC.Linq;
using static MooVC.Data.IFeaturesExtensions_Resources;

/// <summary>
/// Provides extensions that support the assignment of features to a given instance.
/// </summary>
public static partial class IFeaturesExtensions
{
    /// <summary>
    /// Facilitates the inclusion of an <typeparamref name="TAttribute"/> through the specified <paramref name="attribute"/>.
    /// </summary>
    /// <typeparam name="TAttribute">The type of attribute supported by the <paramref name="subject"/>.</typeparam>
    /// <typeparam name="TSubject">
    /// The type of the component that supports the stated <paramref name="attribute"/>, upon which the assignment will be made.
    /// </typeparam>
    /// <param name="subject">The component that supports the stated <paramref name="attribute"/>, upon which the inclusion will be made.</param>
    /// <param name="attribute">A function that facilitates customization of the attribute to be assigned to the <paramref name="subject"/>.</param>
    /// <returns>The <paramref name="subject"/> with the <paramref name="attribute"/> included.</returns>
    public static TSubject Includes<TAttribute, TSubject>(this TSubject subject, Mutator<TAttribute> attribute)
        where TAttribute : class, new()
        where TSubject : IFeatures<TAttribute>
    {
        _ = Guard.Against.Null(attribute, message: IncludesAttributeRequired.Format(typeof(TAttribute), subject));

        TAttribute instance = attribute(new());

        return subject.Includes(instance);
    }

    /// <summary>
    /// Facilitates the inclusion of one or more <typeparamref name="TAttribute"/> through the specified <paramref name="attributes"/>.
    /// </summary>
    /// <typeparam name="TAttribute">The type of attribute supported by the <paramref name="subject"/>.</typeparam>
    /// <typeparam name="TSubject">
    /// The type of the component that supports the stated <paramref name="attribute"/>, upon which the assignment will be made.
    /// </typeparam>
    /// <param name="subject">The component that supports the stated <paramref name="attribute"/>, upon which the inclusion will be made.</param>
    /// <param name="attributes">The attributes to be included within the <paramref name="subject"/>.</param>
    /// <returns>The <paramref name="subject"/> with the <paramref name="attributes"/> included.</returns>
    public static TSubject Includes<TAttribute, TSubject>(this TSubject subject, params TAttribute[] attributes)
        where TAttribute : class
        where TSubject : IFeatures<TAttribute>
    {
        _ = Guard.Against.Null(subject, message: IncludesSubjectRequired.Format(typeof(TSubject), typeof(TAttribute)));
        _ = Guard.Against.Null(attributes, message: IncludesAttributesRequired.Format(typeof(TAttribute), subject));

        attributes.ForEach(subject.Attributes.Add);

        return subject;
    }
}