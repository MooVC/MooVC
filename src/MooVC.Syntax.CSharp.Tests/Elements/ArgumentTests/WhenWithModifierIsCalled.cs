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
        await Assert.That(ReferenceEquals(result, argument)).IsFalse();
        await Assert.That(result.Modifier).IsEqualTo(Argument.Mode.In);
        await Assert.That(argument.Modifier).IsNotEqualTo(Argument.Mode.In);
    }
}