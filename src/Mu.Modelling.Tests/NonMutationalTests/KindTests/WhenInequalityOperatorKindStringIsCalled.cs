namespace Mu.Modelling.NonMutationalTests.KindTests;

public sealed class WhenInequalityOperatorKindStringIsCalled
{
    private const string ReadStoreValue = "ReadStore";
    private const string WriteStoreValue = "WriteStore";

    [Fact]
    public void GivenDifferentValueThenReturnsTrue()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.ReadStore;
        string value = WriteStoreValue;

        // Act
        bool result = subject != value;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenMatchingValueThenReturnsFalse()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.ReadStore;
        string value = ReadStoreValue;

        // Act
        bool result = subject != value;

        // Assert
        result.ShouldBeFalse();
    }
}