namespace Mu.Modelling.MutationalTests.KindTests;

public sealed class WhenInequalityOperatorKindByteIsCalled
{
    private const byte CreationalValue = 0;
    private const byte TransitionalValue = 1;

    [Fact]
    public void GivenDifferentValueThenReturnsTrue()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;
        byte value = TransitionalValue;

        // Act
        bool result = subject != value;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenMatchingValueThenReturnsFalse()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;
        byte value = CreationalValue;

        // Act
        bool result = subject != value;

        // Assert
        result.ShouldBeFalse();
    }
}