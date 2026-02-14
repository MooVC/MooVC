namespace Mu.Modelling.FeatureTests.KindTests;

public sealed class WhenIsMutationalIsCalled
{
    [Fact]
    public void GivenMutationalKindThenReturnsTrue()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.Mutational;

        // Act
        bool result = subject.IsMutational;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenNonMutationalKindThenReturnsFalse()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.NonMutational;

        // Act
        bool result = subject.IsMutational;

        // Assert
        result.ShouldBeFalse();
    }
}