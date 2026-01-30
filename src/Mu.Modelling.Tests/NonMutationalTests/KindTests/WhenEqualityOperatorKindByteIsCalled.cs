namespace Mu.Modelling.NonMutationalTests.KindTests;

public sealed class WhenEqualityOperatorKindByteIsCalled
{
    private const byte ReadStoreValue = 0;
    private const byte WriteStoreValue = 1;

    [Fact]
    public void GivenMatchingValueThenReturnsTrue()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.ReadStore;
        byte value = ReadStoreValue;

        // Act
        bool result = subject == value;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.ReadStore;
        byte value = WriteStoreValue;

        // Act
        bool result = subject == value;

        // Assert
        result.ShouldBeFalse();
    }
}