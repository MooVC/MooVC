namespace MooVC.Syntax.Solution.PropertyTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        object other = PropertyTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}