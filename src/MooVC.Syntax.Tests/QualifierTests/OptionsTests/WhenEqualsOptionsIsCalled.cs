namespace MooVC.Syntax.QualifierTests.OptionsTests;

public sealed class WhenEqualsOptionsIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Qualifier.Options subject = "Block";
        Qualifier.Options other = "Block";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}