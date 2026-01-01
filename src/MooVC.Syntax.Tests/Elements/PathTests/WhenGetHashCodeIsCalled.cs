namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsSameHashCode()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var other = new Path(PathTestsData.DefaultPath);

        // Act
        int hashCode = subject.GetHashCode();
        int otherHashCode = other.GetHashCode();

        // Assert
        hashCode.ShouldBe(otherHashCode);
    }
}