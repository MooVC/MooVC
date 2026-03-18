namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

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
        await Assert.That(result).IsEqualTo(subject.ToString());
    }
}