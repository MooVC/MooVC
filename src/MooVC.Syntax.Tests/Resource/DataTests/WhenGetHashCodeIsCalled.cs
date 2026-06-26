namespace MooVC.Syntax.Resource.DataTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        Data subject = DataTestsData.Create();
        Data other = DataTestsData.Create();

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        _ = await Assert.That(hashCode).IsEqualTo(otherHashCode);
    }
}