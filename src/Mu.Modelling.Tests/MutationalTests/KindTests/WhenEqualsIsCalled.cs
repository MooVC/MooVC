namespace Mu.Modelling.MutationalTests.KindTests;

public sealed class WhenEqualsIsCalled
{
    [Fact]
    public void GivenSameValueThenReturnsTrue()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;
        Mutational.Kind other = Mutational.Kind.Creational;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;
        Mutational.Kind other = Mutational.Kind.Transitional;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}