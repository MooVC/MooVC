namespace MooVC.Syntax.Resource.MetadataTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create();
        Metadata other = MetadataTestsData.Create();

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        _ = await Assert.That(hashCode).IsEqualTo(otherHashCode);
    }
}