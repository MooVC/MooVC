namespace Mu.Modelling.UnitTests;

public sealed class WhenEqualsIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Unit left = ModellingTestData.CreateUnit();
        Unit right = ModellingTestData.CreateUnit();

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Unit subject = ModellingTestData.CreateUnit();

        // Act
        bool result = subject.Equals(null);

        // Assert
        result.ShouldBeFalse();
    }
}