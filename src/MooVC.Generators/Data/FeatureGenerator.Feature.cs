namespace MooVC.Generators.Data;

using System;

/// <summary>
/// Contains the definition of the <see cref="Feature"/> type, which is used to capture information specific to the class
/// that implements the specific feature.
/// </summary>
public partial class FeatureGenerator
{
    private sealed class Feature
        : IEquatable<Feature>
    {
        public Attribute Attribute { get; set; } = new Attribute();

        public bool HasProperty { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Namespace { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public static bool operator ==(Feature? left, Feature? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Feature? left, Feature? right)
        {
            return !(left == right);
        }

        public bool Equals(Feature? other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Feature);
        }

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

        private static bool Equals(Feature? left, Feature? right)
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