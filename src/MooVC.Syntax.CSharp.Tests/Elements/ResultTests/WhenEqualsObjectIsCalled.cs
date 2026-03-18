namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNonResultObjectThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenResultObjectThenReturnsTrue()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        object other = ResultTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        await Assert.That(result).IsTrue();
    }
}