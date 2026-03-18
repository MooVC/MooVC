namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

public sealed class WhenWithModifierIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var argument = new Argument();

        // Act
        Argument result = argument.WithModifier(Argument.Mode.In);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(argument);
        _ = await Assert.That(result.Modifier).IsEqualTo(Argument.Mode.In);
        _ = await Assert.That(argument.Modifier).IsNotEqualTo(Argument.Mode.In);
    }
}