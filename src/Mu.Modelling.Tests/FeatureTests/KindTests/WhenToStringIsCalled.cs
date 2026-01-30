namespace Mu.Modelling.FeatureTests.KindTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenMutationalValueThenReturnsName()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.Mutational;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(nameof(Feature.Kind.Mutational));
    }

    [Fact]
    public void GivenNonMutationalValueThenReturnsName()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.NonMutational;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(nameof(Feature.Kind.NonMutational));
    }
}