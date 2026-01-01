namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

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