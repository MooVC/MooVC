namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentOptionThenReturnsTrue()
    {
        // Arrange
        Qualifier.Options subject = "Block";
        object other = (Qualifier.Options)"Block";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}