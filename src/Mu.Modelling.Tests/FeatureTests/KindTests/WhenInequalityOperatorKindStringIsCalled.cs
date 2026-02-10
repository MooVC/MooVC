namespace Mu.Modelling.FeatureTests.KindTests;

public sealed class WhenInequalityOperatorKindStringIsCalled
{
    private const string MutationalValue = "Mutational";
    private const string NonMutationalValue = "NonMutational";

    [Fact]
    public void GivenDifferentValueThenReturnsTrue()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.Mutational;
        string value = NonMutationalValue;

        // Act
        bool result = subject != value;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenMatchingValueThenReturnsFalse()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.Mutational;
        string value = MutationalValue;

        // Act
        bool result = subject != value;

        // Assert
        result.ShouldBeFalse();
    }
}