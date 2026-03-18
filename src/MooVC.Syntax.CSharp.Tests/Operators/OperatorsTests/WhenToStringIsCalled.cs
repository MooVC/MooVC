namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Operators subject = Operators.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }
}