namespace MooVC.Generators.Data;

using System;

/// <summary>
/// Contains the definition of the <see cref="Attribute"/> type, which is used to capture information specific to the attribute
/// that forms the subject of the feature.
/// </summary>
public partial class AttributeGenerator
{
    /// <summary>
    /// The definition of the <see cref="Attribute"/> type, which is used to capture information specific to the attribute that
    /// forms the subject of the feature.
    /// </summary>
    public sealed class Attribute
        : IEquatable<Attribute>
    {
        /// <summary>
        /// Creates an instance of <see cref="Attribute"/>, which is used to capture information specific to the attribute that
        /// forms the subject of the feature.
        /// </summary>
        internal Attribute()
        {
        }

        /// <summary>
        /// Gets the name of the type nominated as an attribute that is exhibited by the subject.
        /// </summary>
        /// <value>
        /// The name of the type nominated as an attribute that is exhibited by the subject.
        /// </value>
        public string Name { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets the namespace of the type nominated as an attribute that is exhibited by the subject.
        /// </summary>
        /// <value>
        /// The namespace of the type nominated as an attribute that is exhibited by the subject.
        /// </value>
        public string Namespace { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether or not the attribute implementation provides a default constructor.
        /// </summary>
        /// <value>
        /// a value indicating whether or not the attribute implementation provides a default constructor.
        /// </value>
        public bool HasDefaultConstructor { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether or not an extension methods class exists for the attribute implementation.
        /// </summary>
        /// <value>
        /// A value indicating whether or not an extension methods class exists for the attribute implementation.
        /// </value>
        public bool HasExtension { get; internal set; }

        /// <summary>
        /// Determines whether two specified instances of <see cref="Attribute"/> are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>true if <paramref name="left"/> and <paramref name="right"/> represent the same value; otherwise, false.</returns>
        public static bool operator ==(Attribute? left, Attribute? right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="Attribute"/> are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>true if <paramref name="left"/> and <paramref name="right"/> do not represent the same value; otherwise, false.</returns>
        public static bool operator !=(Attribute? left, Attribute? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Attribute"/> instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
        /// <remarks>
        /// This method overrides <see cref="object.Equals(object)"/> to provide a way to compare two <see cref="Attribute"/> instances.
        /// </remarks>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Attribute);
        }

        /// <summary>
        /// Indicates whether the current <see cref="Attribute"/> instance is equal to another <see cref="Attribute"/> instance.
        /// </summary>
        /// <param name="other">An instance of <see cref="Attribute"/> to compare with this instance.</param>
        /// <returns>true if the current instance is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <remarks>
        /// This method implements the <see cref="IEquatable{T}"/> interface and provides a type-safe way to compare two <see cref="Attribute"/> instances.
        /// </remarks>
        public bool Equals(Attribute? other)
        {
            return Equals(this, other);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Attribute"/> instance.</returns>
        /// <remarks>
        /// The hash code is calculated based on the values.
        /// This implementation is suitable for use in hashing algorithms and data structures like a hash table.
        /// </remarks>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 37;

                hash = (hash * 53) + HasDefaultConstructor.GetHashCode();
                hash = (hash * 53) + HasExtension.GetHashCode();
                hash = (hash * 53) + Name.GetHashCode();
                hash = (hash * 53) + Namespace.GetHashCode();

                return hash;
            }
        }

        private static bool Equals(Attribute? left, Attribute? right)
        {
            if (left is null || right is null)
            {
                return false;
            }

            if (ReferenceEquals(left, right))
            {
                return true;
            }

            return left.HasDefaultConstructor == right.HasDefaultConstructor
                && left.HasExtension == right.HasExtension
                && left.Name == right.Name
                && left.Namespace == right.Namespace;
        }
    }
}