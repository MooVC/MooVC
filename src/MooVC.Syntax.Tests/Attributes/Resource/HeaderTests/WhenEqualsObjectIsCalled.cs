namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();

        // Act
        bool result = subject.Equals(null);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();
        object other = HeaderTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}