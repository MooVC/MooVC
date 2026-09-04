namespace MooVC.Syntax.CSharp.NewTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenNewConstraintThenReturnsValue()
    {
        // Arrange
        New subject = "new()";

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}