namespace MooVC.Modelling.FileTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        File subject = FileTestsData.Create();
        File other = FileTestsData.Create();

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        _ = await Assert.That(hashCode).IsEqualTo(otherHashCode);
    }
}