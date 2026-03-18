namespace MooVC.Syntax.Resource.ItemTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        Item other = ItemTestsData.Create();

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        _ = await Assert.That(hashCode).IsEqualTo(otherHashCode);
    }
}