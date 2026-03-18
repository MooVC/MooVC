namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenImplicitOperatorFromTypeIsCalled
{
    [Test]
    public async Task GivenNullThenThrows()
    {
        // Arrange
        Type? value = default;

        // Act
        Func<Result> result = () => value!;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenTypeThenResultUsesSymbolType()
    {
        // Arrange
        Type value = typeof(Guid);

        // Act
        Result result = value;

        // Assert
        await Assert.That(result.Type.Name).IsEqualTo(new Symbol.Moniker(nameof(Guid)));
    }
}