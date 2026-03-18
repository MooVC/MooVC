namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        Resource other = ResourceTestsData.Create();

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        _ = await Assert.That(hashCode).IsEqualTo(otherHashCode);
    }
}