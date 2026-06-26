namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Implementation subject = ImplementationTestsData.Create();
        object other = ImplementationTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}