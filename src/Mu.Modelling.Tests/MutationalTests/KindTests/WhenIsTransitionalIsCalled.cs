namespace Mu.Modelling.MutationalTests.KindTests;

public sealed class WhenIsTransitionalIsCalled
{
    [Fact]
    public void GivenTransitionalKindThenReturnsTrue()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Transitional;

        // Act
        bool result = subject.IsTransitional;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenCreationalKindThenReturnsFalse()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;

        // Act
        bool result = subject.IsTransitional;

        // Assert
        result.ShouldBeFalse();
    }
}