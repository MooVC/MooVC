namespace MooVC.Syntax.CSharp.OptionsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNonOptionsObjectThenReturnsFalse()
    {
        // Arrange
        var subject = new Options();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenOptionsObjectThenReturnsTrue()
    {
        // Arrange
        var subject = new Options();
        object other = new Options();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}