namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Base subject = BaseTestsData.Create();
        object other = BaseTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}