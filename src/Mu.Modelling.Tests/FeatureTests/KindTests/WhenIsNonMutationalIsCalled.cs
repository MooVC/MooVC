namespace Mu.Modelling.FeatureTests.KindTests;

public sealed class WhenIsNonMutationalIsCalled
{
    [Fact]
    public void GivenNonMutationalKindThenReturnsTrue()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.NonMutational;

        // Act
        bool result = subject.IsNonMutational;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenMutationalKindThenReturnsFalse()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.Mutational;

        // Act
        bool result = subject.IsNonMutational;

        // Assert
        result.ShouldBeFalse();
    }
}