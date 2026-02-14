namespace Mu.Modelling.MutationalTests.KindTests;

public sealed class WhenEqualityOperatorKindStringIsCalled
{
    private const string CreationalValue = "Creational";
    private const string TransitionalValue = "Transitional";

    [Fact]
    public void GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;
        string value = CreationalValue;

        // Act
        bool result = subject == value;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;
        string value = TransitionalValue;

        // Act
        bool result = subject == value;

        // Assert
        result.ShouldBeFalse();
    }
}