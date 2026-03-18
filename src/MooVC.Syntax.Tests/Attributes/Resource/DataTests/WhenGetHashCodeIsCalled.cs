namespace MooVC.Syntax.Attributes.Resource.DataTests;

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
        await Assert.That(hashCode).IsEqualTo(otherHashCode);
    }
}