namespace Mu.Modelling.MutationalTests.KindTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenCreationalValueThenReturnsName()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Creational;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(nameof(Mutational.Kind.Creational));
    }

    [Fact]
    public void GivenTransitionalValueThenReturnsName()
    {
        // Arrange
        Mutational.Kind subject = Mutational.Kind.Transitional;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(nameof(Mutational.Kind.Transitional));
    }
}