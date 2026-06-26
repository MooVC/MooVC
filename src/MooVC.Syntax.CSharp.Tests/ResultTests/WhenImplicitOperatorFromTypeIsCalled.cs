namespace MooVC.Syntax.CSharp.ResultTests;

using Type = System.Type;

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
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenTypeThenResultUsesSymbolType()
    {
        // Arrange
        Type value = typeof(Guid);
        Qualification expected = value;

        // Act
        Result result = value;

        // Assert
        _ = await Assert.That(result.Type.Name).IsEqualTo(expected);
    }
}