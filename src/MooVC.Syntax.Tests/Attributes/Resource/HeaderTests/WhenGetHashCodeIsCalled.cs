namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();
        Header other = HeaderTestsData.Create();

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        hashCode.ShouldBe(otherHashCode);
    }
}