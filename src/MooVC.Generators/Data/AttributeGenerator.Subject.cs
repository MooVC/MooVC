namespace MooVC.Generators.Data;

using System;

/// <summary>
/// Contains the definition of the <see cref="Subject"/> type, which is used to capture information specific to the class
/// that implements the specific feature.
/// </summary>
public partial class AttributeGenerator
{
    /// <summary>
    /// The definition of the <see cref="Subject"/> type, which is used to capture information specific to the class
    /// that implements the specific feature.
    /// </summary>
    public sealed class Subject
        : IEquatable<Subject>
    {
        /// <summary>
        /// Creates an instance of <see cref="Subject"/>, which is used to capture information specific to the class
        /// that implements the specific feature.
        /// </summary>
        internal Subject()
        {
        }

        /// <summary>
        /// Gets the definition of the attribute exhibited by the class identified as the subject.
        /// </summary>
        /// <value>
        /// The definition of the attribute exhibited by the class identified as the subject.
        /// </value>
        public Attribute Attribute { get; internal set; } = new Attribute();

        /// <summary>
        /// Gets a value indicating whether or not the subject implements the property associated with the attribute.
        /// </summary>
        /// <value>
        /// Denotes whether or not the subject implements the property associated with the attribute.
        /// </value>
        public bool HasProperty { get; internal set; }

        /// <summary>
        /// Gets the name of the class that exhibits the attribute.
        /// </summary>
        /// <value>
        /// The name of the class that exhibits the attribute.
        /// </value>
        public string Name { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets the namespace of the class that exhibits the attribute.
        /// </summary>
        /// <value>
        /// The namespace of the class that exhibits the attribute.
        /// </value>
        public string Namespace { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets the type name of the class that exhibits the attribute.
        /// </summary>
        /// <value>
        /// The type name of the class that exhibits the attribute.
        /// </value>
        public string Type { get; internal set; } = string.Empty;

        /// <summary>
        /// Determines whether two specified instances of <see cref="Subject"/> are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>true if <paramref name="left"/> and <paramref name="right"/> represent the same value; otherwise, false.</returns>
        public static bool operator ==(Subject? left, Subject? right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="Subject"/> are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>true if <paramref name="left"/> and <paramref name="right"/> do not represent the same value; otherwise, false.</returns>
        public static bool operator !=(Subject? left, Subject? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Subject"/> instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
        /// <remarks>
        /// This method overrides <see cref="object.Equals(object)"/> to provide a way to compare two <see cref="Subject"/> instances.
        /// </remarks>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Subject);
        }

        /// <summary>
        /// Indicates whether the current <see cref="Subject"/> instance is equal to another <see cref="Subject"/> instance.
        /// </summary>
        /// <param name="other">An instance of <see cref="Subject"/> to compare with this instance.</param>
        /// <returns>true if the current instance is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <remarks>
        /// This method implements the <see cref="IEquatable{T}"/> interface and provides a type-safe way to compare two <see cref="Subject"/> instances.
        /// </remarks>
        public bool Equals(Subject? other)
        {
            return Equals(this, other);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Subject"/> instance.</returns>
        /// <remarks>
        /// The hash code is calculated based on the values.
        /// This implementation is suitable for use in hashing algorithms and data structures like a hash table.
        /// </remarks>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = (hash * 23) + Attribute.GetHashCode();
                hash = (hash * 23) + HasProperty.GetHashCode();
                hash = (hash * 23) + Name.GetHashCode();
                hash = (hash * 23) + Namespace.GetHashCode();
                hash = (hash * 23) + Type.GetHashCode();

                return hash;
            }
        }

        private static bool Equals(Subject? left, Subject? right)
        {
            if (left is null || right is null)
            {
                return false;
            }

            if (ReferenceEquals(left, right))
            {
                return true;
            }

            return left.Attribute == right.Attribute
                && left.HasProperty == right.HasProperty
                && left.Name == right.Name
                && left.Namespace == right.Namespace
                && left.Type == right.Type;
        }
    }
}