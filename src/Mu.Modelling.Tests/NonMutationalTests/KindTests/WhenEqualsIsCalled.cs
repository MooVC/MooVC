namespace Mu.Modelling.NonMutationalTests.KindTests;

public sealed class WhenEqualsIsCalled
{
    [Fact]
    public void GivenSameValueThenReturnsTrue()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.ReadStore;
        NonMutational.Kind other = NonMutational.Kind.ReadStore;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.ReadStore;
        NonMutational.Kind other = NonMutational.Kind.WriteStore;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}