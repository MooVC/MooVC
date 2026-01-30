namespace Mu.Modelling.FeatureTests.KindTests;

public sealed class WhenInequalityOperatorKindByteIsCalled
{
    private const byte MutationalValue = 0;
    private const byte NonMutationalValue = 1;

    [Fact]
    public void GivenDifferentValueThenReturnsTrue()
    {
        // Arrange
        Feature.Kind subject = Feature.Kind.Mutational;
        byte value = NonMutationalValue;

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
        byte value = MutationalValue;

        // Act
        bool result = subject != value;

        // Assert
        result.ShouldBeFalse();
    }
}