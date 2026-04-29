namespace MooVC.Syntax.Project.OutputTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Output subject = OutputTestsData.Create();
        object other = OutputTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Output subject = OutputTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}