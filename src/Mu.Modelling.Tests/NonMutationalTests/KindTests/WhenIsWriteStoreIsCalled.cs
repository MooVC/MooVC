namespace Mu.Modelling.NonMutationalTests.KindTests;

public sealed class WhenIsWriteStoreIsCalled
{
    [Fact]
    public void GivenWriteStoreKindThenReturnsTrue()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.WriteStore;

        // Act
        bool result = subject.IsWriteStore;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenReadStoreKindThenReturnsFalse()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.ReadStore;

        // Act
        bool result = subject.IsWriteStore;

        // Assert
        result.ShouldBeFalse();
    }
}