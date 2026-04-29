namespace MooVC.Syntax.CSharp.ArgumentTests;

public sealed class WhenWithModifierIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var argument = new Argument();

        // Act
        Argument result = argument.WithModifier(Argument.Modes.In);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(argument);
        _ = await Assert.That(result.Modifier).IsEqualTo(Argument.Modes.In);
        _ = await Assert.That(argument.Modifier).IsNotEqualTo(Argument.Modes.In);
    }
}