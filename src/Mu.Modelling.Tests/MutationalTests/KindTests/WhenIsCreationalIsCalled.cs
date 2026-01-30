namespace Mu.Modelling.MutationalTests.KindTests;

public sealed class WhenIsCreationalIsCalled
{
    [Fact]
    public void GivenCreationalKindThenReturnsTrue()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;

        // Act
        bool result = subject.IsCreational;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenTransitionalKindThenReturnsFalse()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Transitional;

        // Act
        bool result = subject.IsCreational;

        // Assert
        result.ShouldBeFalse();
    }
}