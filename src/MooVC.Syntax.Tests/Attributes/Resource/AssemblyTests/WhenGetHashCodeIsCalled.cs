namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();
        Assembly other = AssemblyTestsData.Create();

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        hashCode.ShouldBe(otherHashCode);
    }
}