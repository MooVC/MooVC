namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();

        // Act
        bool result = subject.Equals(null);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();
        object other = AssemblyTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}