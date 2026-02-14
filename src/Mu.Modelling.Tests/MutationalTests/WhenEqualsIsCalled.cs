namespace Mu.Modelling.MutationalTests;

public sealed class WhenEqualsIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Mutational left = ModellingTestData.CreateMutational();
        Mutational right = ModellingTestData.CreateMutational();

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Mutational subject = ModellingTestData.CreateMutational();

        // Act
        bool result = subject.Equals(null);

        // Assert
        result.ShouldBeFalse();
    }
}