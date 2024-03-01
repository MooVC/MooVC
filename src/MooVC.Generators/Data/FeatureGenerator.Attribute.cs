namespace MooVC.Generators.Data;

using System;

/// <summary>
/// Contains the definition of the <see cref="Attribute"/> type, which is used to capture information specific to the attribute
/// that forms the subject of the feature.
/// </summary>
public partial class FeatureGenerator
{
    private sealed class Attribute
        : IEquatable<Attribute>
    {
        public string Name { get; set; } = string.Empty;

        public string Namespace { get; set; } = string.Empty;

        public bool HasDefaultConstructor { get; set; }

        public bool HasExtension { get; set; }

        public static bool operator ==(Attribute? left, Attribute? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Attribute? left, Attribute? right)
        {
            return !(left == right);
        }

        public bool Equals(Attribute? other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Attribute);
        }

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