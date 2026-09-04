namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsModifiers()
    {
        // Arrange
        const string value = "ref readonly";

        // Act
        Result.Modifiers subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
    }
}