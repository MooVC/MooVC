namespace Mu.Modelling.FeatureTests.KindTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenSameValueThenHashesMatch()
    {
        // Arrange
        Feature.Kind left = Feature.Kind.Mutational;
        Feature.Kind right = Feature.Kind.Mutational;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValueThenHashesDiffer()
    {
        // Arrange
        Feature.Kind left = Feature.Kind.Mutational;
        Feature.Kind right = Feature.Kind.NonMutational;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}