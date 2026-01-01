namespace MooVC.Syntax.Concepts.ResourceTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        Resource other = ResourceTestsData.Create();

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        hashCode.ShouldBe(otherHashCode);
    }
}