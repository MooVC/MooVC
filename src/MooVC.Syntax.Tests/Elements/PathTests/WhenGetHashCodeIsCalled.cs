namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var other = new Path(PathTestsData.DefaultPath);

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        await Assert.That(hashCode).IsEqualTo(otherHashCode);
    }
}